using BLOG.Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace BLOG.Models
{
    public class UserDetailVM
    {
        public string Id { get; set; }
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Image { get; set; }

        public string Description { get; set; }

        public HashSet<Article> Articles { get; set; }
        public int ArticleId { get; set; }

    }
}
