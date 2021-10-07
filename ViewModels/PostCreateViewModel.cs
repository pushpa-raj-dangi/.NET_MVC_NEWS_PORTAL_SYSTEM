using Microsoft.AspNetCore.Http;
using NewsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NewsWebApp.ViewModels
{
    public class PostCreateViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Post Title")]
        [Required]
        public string Name { get; set; }
        public string Slug { get; set; }
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
        public IFormFile Picture { get; set; }
        public PostStatus PostStatus { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public List<int> SelectedCategory { get; set; }
        public List<int> SelectedTag { get; set; }
        public AppUser AppUser { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public virtual ICollection<PostTag> PostTags { get; set; }
        public virtual ICollection<PostCategory> PostCategories { get; set; }
        public ICollection<Post> Posts { get; set; }
        public Post Post { get; set; }
        public string UserId { get; set; }

        public PostCreateViewModel()
        {
            PostTags = new Collection<PostTag>();
            PostCategories = new Collection<PostCategory>();
        }

    }
}
