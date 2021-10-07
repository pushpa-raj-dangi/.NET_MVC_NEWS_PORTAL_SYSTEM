using NewsWebApp.Models;
using System.Collections.Generic;

namespace NewsWebApp.ViewModels
{
    public class PostViewModel
    {
        public ICollection<Post> Posts { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public Post Post { get; set; }

    }
}
