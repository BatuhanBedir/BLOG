using BLOG.Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace BLOG.Models
{
    public class EditArticleVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter title")]
        [MinLength(5, ErrorMessage = "Title can not be shorter than 5 chars")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter title")]
        [MinLength(10, ErrorMessage = "Content can not be shorter than 10 chars")]
        public string Content { get; set; }
        public decimal AvgReadingTime { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public ICollection<Category> Categories { get; set; }
    }
}
