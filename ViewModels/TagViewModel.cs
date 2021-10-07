using NewsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWebApp.ViewModels
{
    public class TagViewModel    
    {

        public IEnumerable<Tag> Tags { get; set; }

        public Tag Tag { get; set; }


    }
}
