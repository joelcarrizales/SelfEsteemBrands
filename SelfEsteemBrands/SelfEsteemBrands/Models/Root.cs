using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfEsteemBrands.Models
{
    public class Root
    {
        public int total_count { get; set; }
        public bool incomplete_results { get; set; }
        public List<GitHubRepo> items { get; set; }
    }
}
