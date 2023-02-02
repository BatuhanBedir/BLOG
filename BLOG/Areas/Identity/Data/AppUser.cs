using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLOG.Entities.Concrete;
using Microsoft.AspNetCore.Identity;

namespace BLOG.Areas.Identity.Data;

// Add profile data for application users by adding properties to the AppUser class
public class AppUser : IdentityUser
{
	public AppUser()
	{
		Articles = new HashSet<Article>();
		Category = new HashSet<Category>();
	}
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Description { get; set; }
	public string? Image { get; set; }
	public DateTime RegistrationDate { get; set; } = DateTime.Now;
    public ICollection<Article>? Articles { get; set; }  
	public ICollection<Category>? Category { get; set; }
}

