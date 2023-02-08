using BLOG.Areas.Identity.Data;
using BLOG.Entities.Concrete;

namespace BLOG.Models
{
    public class AppUserIndexVM
    {
        public IEnumerable<AppUser> AppUsers { get; set; }
    }
}
