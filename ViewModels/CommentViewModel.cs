using NewsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWebApp.ViewModels
{
    public class CommentViewModel
    {
        public string Comment { get; set; }
        public List<Comment> Comments { get; set; }
        public int PostId { get; set; }
    }
}
