using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfEsteemBrands.Services
{
    public class GitHubService
    {
        private const string URL = "https://api.github.com/search/repositories?q=language:javascript stars:>10000 sort:stars-desc&per_page=5";

        public GitHubService()
        {

        }
    }
}
