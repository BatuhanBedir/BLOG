using BLOG.Entities.Concrete;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace BLOG.Models
{
    public class ArticleUserVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter title")]
        [MinLength(5,ErrorMessage = "Title can not be shorter than 5 chars")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter title")]
        [MinLength(10, ErrorMessage = "Content can not be shorter than 10 chars")]
        public string Content { get; set; }
        public string UserId { get; set; }

        public decimal AvgReadingTime { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedDate { get; set; }
        public IEnumerable<Article> Articles { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        
    }
}
