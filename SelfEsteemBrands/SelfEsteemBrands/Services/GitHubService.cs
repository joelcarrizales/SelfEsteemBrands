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
        public IEnumerable<GitHubRepo> GetTopStarredRepos(string language);
    }

    public class GitHubService : IGitHubService
    {
        private const string URL = "https://api.github.com/search/repositories?q=language:{0} stars:>={1} sort:stars-desc&per_page=5";
        private string JSON = "";

        public GitHubService()
        {

        }

        public IEnumerable<GitHubRepo> GetTopStarredRepos(string language)
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
                // there might be more results with a higher star count, try again
                minStars = root.Items.Last<GitHubRepo>().stargazers_count;
            }

            return root.Items;
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
