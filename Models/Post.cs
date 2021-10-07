
using NewsWebApp.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace NewsWebApp.Models
{
    public class Post
    {
        private readonly ApplicationDbContext _context;

        public Post(ApplicationDbContext context)
        {
            _context = context;
        }
        public int Id { get; set; }
        [Required]
        [Display(Name = "Post Title")]
        public string Name { get; set; }
        public string Slug { get; set; }
        
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
        public string Picture { get; set; }
        public AppUser AppUser { get; set; }

        [Required]
        public string AppUserId { get; set; }

        public PostStatus PostStatus { get; set; }
        [Required]
        public IEnumerable<Category> Categories { get; set; }

        [Required]
        public IEnumerable<Tag> Tags { get; set; }
        public virtual ICollection<PostTag> PostTags { get; set; }
        public virtual ICollection<PostCategory> PostCategories { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }


        public ICollection<Comment> Comments { get; set; }


        public Post()
        {
            PostTags = new Collection<PostTag>();
            Comments = new Collection<Comment>();
            PostCategories = new Collection<PostCategory>();
            CreatedDate = DateTime.UtcNow;
        }





    }
}
