using NewsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWebApp.ViewModels
{
    public class HomeViewModel
    {

        public IEnumerable<Post> PoliticsNews { get; set; }

        public IEnumerable<Post> SportsNews { get; set; }
        public IEnumerable<Post> EntertainmentNews { get; set; }
        public IEnumerable<Post> TechnologyNews { get; set; }
        public IEnumerable<Post> InternationalNews { get; set; }

        public string Search { get; set; }


        public IEnumerable<Post> BusinessNews { get; set; }
        public IEnumerable<Post> FeatureNews { get; set; }
        public IEnumerable<Post> LatestUpdate { get; set; }
        public IEnumerable<Category> Categories { get; set; }

        public IEnumerable<Post> PostsByAuthor { get; set; }


    }
}
