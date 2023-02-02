using BLOG.Areas.Identity.Data;
using BLOG.Entities.Abstract;

namespace BLOG.Entities.Concrete
{
    public class Category:BaseEntity
    {
        public Category()
        {
            Articles = new HashSet<Article>();
            AppUsers = new HashSet<AppUser>();
        }
        public string Name { get; set; }
        public ICollection<Article> Articles { get; set; }
        public ICollection<AppUser> AppUsers { get; set; }
    }
}
