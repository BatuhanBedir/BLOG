using BLOG.Areas.Identity.Data;
using BLOG.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace BLOG.Entities.Concrete
{
    public class Article 
    {
        public Article()
        {
            Categories = new HashSet<Category>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter title")]
        [MinLength(5, ErrorMessage = "Title can not be longer than 5 chars")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter title")]
        [MinLength(10, ErrorMessage = "Content can not be longer than 10 chars")]
        public string Content { get; set; }
        public int ViewCount { get; set; }
        public decimal AvgReadingTime { get; set; }
        public DateTime CreatedDate { get; set; }= DateTime.Now;
        public ICollection<Category> Categories { get; set; }

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
