using NewsWebApp.Helpers;
using NewsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWebApp.ViewModels
{
    public class PostDetailViewModel
    {
        public int PostId { get; set; }

        [Display(Name = "Post Title")]
        [Required]
        public string Name { get; set; }
        public string Slug { get; set; }

        public string Content { get; set; }

        public IEnumerable<Category> Categories { get; set; }
        public List<int> SelectedCategory { get; set; }
        public List<int> SelectedTag { get; set; }

        public AppUser AppUser { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public IEnumerable<Comment> ListComments { get; set; }



        public virtual ICollection<PostTag> PostTags { get; set; }
        public virtual ICollection<PostCategory> PostCategories { get; set; }

        public ICollection<Post> Posts { get; set; }
        public Post Post { get; set; }
        public string UserId { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public string Comment { get; set; }
        public PostDetailViewModel()
        {
            Comments = new Collection<Comment>();
            PostTags = new Collection<PostTag>();
            PostCategories = new Collection<PostCategory>();
        }

        public string GetTimeAgo(DateTime dateTime)
        {
            string result = string.Empty;
            var timeSpan = DateTime.Now.Subtract(dateTime);

            if (timeSpan <= TimeSpan.FromSeconds(60))
            {
                result = string.Format("{0} seconds ago", timeSpan.Seconds);
            }
            else if (timeSpan <= TimeSpan.FromMinutes(60))
            {
                result = timeSpan.Minutes > 1 ?
                    String.Format("about {0} minutes ago", timeSpan.Minutes) :
                    "about a minute ago";
            }
            else if (timeSpan <= TimeSpan.FromHours(24))
            {
                result = timeSpan.Hours > 1 ?
                    String.Format("about {0} hours ago", timeSpan.Hours) :
                    "about an hour ago";
            }
            else if (timeSpan <= TimeSpan.FromDays(30))
            {
                result = timeSpan.Days > 1 ?
                    String.Format("about {0} days ago", timeSpan.Days) :
                    "yesterday";
            }
            else if (timeSpan <= TimeSpan.FromDays(365))
            {
                result = timeSpan.Days > 30 ?
                    String.Format("about {0} months ago", timeSpan.Days / 30) :
                    "about a month ago";
            }
            else
            {
                result = timeSpan.Days > 365 ?
                    String.Format("about {0} years ago", timeSpan.Days / 365) :
                    "about a year ago";
            }

            return result;
        }

    }
}
