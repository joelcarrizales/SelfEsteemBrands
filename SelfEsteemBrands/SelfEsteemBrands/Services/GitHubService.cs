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
        private const string URL = "https://api.github.com/search/repositories?q=language:javascript stars:>10000 sort:stars-desc&per_page=5";
        private string JSON = "";

        public GitHubService()
        {

        }

        public IEnumerable<GitHubRepo> GetTopStarredRepos(string language)
        {
            GetJSON("javascript").Wait();
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            Root root = JsonSerializer.Deserialize<Root>(JSON);

            return root.items;
        }

        private async Task<bool> GetJSON(string language)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "GitHubService");
            JSON = await client.GetStringAsync(URL);
            return true;
        }
    }
}
