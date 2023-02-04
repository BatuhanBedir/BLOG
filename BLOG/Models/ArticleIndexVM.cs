using BLOG.Entities.Concrete;

namespace BLOG.Models
{
    public class ArticleIndexVM
    {
        public IEnumerable<Article> Articles { get; set; }
        public int ArticleId { get; set; }

        public IEnumerable<Category> Categories { get; set; }
        public string Title { get; set; }
        public int ViewCount { get; set; }
        public string Content { get;set; }
        public string Writer { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedTime { get; set; }
        public decimal AvgReadingTime { get; set; }
    }
}
