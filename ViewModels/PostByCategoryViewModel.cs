using NewsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWebApp.ViewModels
{
    public class PostByCategoryViewModel

    {
        public List<Post> Posts { get; set; }
        public int CurrentPageIndex { get; set; }
        public int PageCount { get; set; }


    }
}
