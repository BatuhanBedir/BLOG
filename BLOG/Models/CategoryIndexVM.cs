using BLOG.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace BLOG.Models
{
    public class CategoryIndexVM
    {
        [Required(ErrorMessage = "Please enter CategoryName")]
        [Remote("IsCategoryNameAvailable", "Category", HttpMethod = "POST",ErrorMessage ="Already exists.")]
        public string CategoryName { get; set; }//ModelState
        public IEnumerable<Category> Categories { get; set; }
    }
}
