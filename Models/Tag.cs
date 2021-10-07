using System.ComponentModel.DataAnnotations;

namespace NewsWebApp.Models
{
    public class Tag
    {
        public int Id { get; set; }
        [Required]
        [Display(Name="Title")]
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}