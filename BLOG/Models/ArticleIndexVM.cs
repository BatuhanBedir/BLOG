using BLOG.Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace BLOG.Models
{
    public class ArticleIndexVM
    {
        public IEnumerable<Article> Articles { get; set; }
        public int ArticleId { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        [Required(ErrorMessage = "Please enter title")]
        [MinLength(5, ErrorMessage = "Content can not be shorter than 5 chars")]
        public string Title { get; set; }
        public int ViewCount { get; set; }

        [Required(ErrorMessage = "Please enter title")]
        [MinLength(10, ErrorMessage = "Content can not be shorter than 10 chars")]
        public string Content { get;set; }
        public string Writer { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedTime { get; set; }
        public decimal AvgReadingTime { get; set; }

        public string Image { get; set; }
    }
}
