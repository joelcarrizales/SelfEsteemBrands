using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SelfEsteemBrands.Models;
using SelfEsteemBrands.Services;

namespace SelfEsteemBrands.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitHubController : ControllerBase
    {
        private readonly IGitHubService _gitHubService;

        public GitHubController(IGitHubService gitHubService)
        {
            _gitHubService = gitHubService;
        }

        [HttpGet("{language}")]
        public List<GitHubRepo> Get(string language)
        {
            return _gitHubService.GetTopStarredRepos(language).ToList();
        }
    }
}