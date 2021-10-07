using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWebApp.Models
{
    public class Comment
    {
        public int CommentId { get; set; }

        [Required]
        public string CContent { get; set; }
        public Post Post { get; set; }
        public int PostId { get; set; }

        public AppUser AppUser { get; set; }

        public DateTime DateComment { get; set; }
        public bool IsApproved { get; set; }


    }
}
