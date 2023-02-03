using BLOG.Areas.Identity.Data;
using BLOG.Entities.Abstract;

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
        public string Name { get; set; }
        public ICollection<Article> Articles { get; set; }
        public ICollection<AppUser> AppUsers { get; set; }
    }
}
