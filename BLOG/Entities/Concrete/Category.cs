using BLOG.Areas.Identity.Data;
using BLOG.Entities.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BLOG.Entities.Concrete
{
    public class Category
    {
        public Category()
        {
            Articles = new HashSet<Article>();
            AppUsers = new HashSet<AppUser>();
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter CategoryName")]
        [Remote("IsCategoryNameAvailable", "Category", HttpMethod = "POST", ErrorMessage = "Already exists.")]
        public string Name { get; set; }
        public ICollection<Article> Articles { get; set; }
        public ICollection<AppUser> AppUsers { get; set; }
    }
}
