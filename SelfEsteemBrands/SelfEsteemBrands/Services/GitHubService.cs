using SelfEsteemBrands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public GitHubService()
        {

        }

        public IEnumerable<GitHubRepo> GetTopStarredRepos(string language)
        {
            return new List<GitHubRepo>();
        }
    }
}
