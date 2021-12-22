using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfEsteemBrands.Models
{
    public class GitHubRepo
    {
        public int id { get; set; }
        public string name { get; set; }
        public string full_name { get; set; }
        public string html_url { get; set; }
        public string description { get; set; }
        public DateTime updated_at { get; set; }
        public int stargazers_count { get; set; }
        public string language { get; set; }
        public int watchers { get; set; }
        public string default_branch { get; set; }
    }
}
