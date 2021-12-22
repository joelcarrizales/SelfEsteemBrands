using SelfEsteemBrands.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SelfEsteemBrands.Services
{
    public interface IGitHubService
    {
        public Root GetTopStarredRepos(string language);
    }

    public class GitHubService : IGitHubService
    {
        private const string URL = "https://api.github.com/search/repositories?q=language:{0} stars:>={1} sort:stars-desc&per_page=5";
        private string JSON = "";

        public GitHubService()
        {

        }

        public Root GetTopStarredRepos(string language)
        {
            Root root = new Root();
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            int minStars = 0;
            while (root.Incomplete_results)
            {
                GetJSON(language, minStars).Wait();
                root = JsonSerializer.Deserialize<Root>(JSON, options);
                // if an invalid language is entered, github just sends everything. watch for it.
                if (!ValidateRepos(root.Items, language))
                {
                    root = new Root("There are no GitHub repositories using that language. Are you sure it was typed correctly?");
                    break;
                }
                // there might be more results with a higher star count, try again
                minStars = root.Items.Last<GitHubRepo>().stargazers_count;
            }

            return root;
        }

        private bool ValidateRepos(List<GitHubRepo> gitHubRepos, string language)
        {
            bool isValid = true;
            foreach (GitHubRepo repo in gitHubRepos)
            {
                if (repo.language == null || repo.language.ToLower() != language.ToLower())
                {
                    isValid = false;
                    break;
                }
            }

            return isValid;
        }

        private async Task<bool> GetJSON(string language, int minStars)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "GitHubService");
            JSON = await client.GetStringAsync(String.Format(URL, language, minStars));
            return true;
        }
    }
}
