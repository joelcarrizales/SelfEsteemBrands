using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfEsteemBrands.Models
{
    public class Root
    {
        public int Total_count { get; set; }
        public bool Incomplete_results { get; set; }
        public List<GitHubRepo> Items { get; set; }

        public Root()
        {
            Incomplete_results = true;
        }
    }
}
