using BLOG.Areas.Identity.Data;
using BLOG.Entities.Abstract;

namespace BLOG.Entities.Concrete
{
    public class Article 
    {
        public Article()
        {
            Categories = new HashSet<Category>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; }
        public decimal AvgReadingTime { get; set; }
        public DateTime CreatedDate { get; set; }= DateTime.Now;
        public ICollection<Category> Categories { get; set; }

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
