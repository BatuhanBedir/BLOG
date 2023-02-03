using BLOG.Areas.Identity.Data;
using BLOG.Entities.Concrete;
using BLOG.Repository.Abstract;
using Microsoft.EntityFrameworkCore;


namespace BLOG.Repository.Concrete
{
    public class ArticleRepository : GenericRepository<Article>, IArticleRepository
    {
        private readonly AppDbContext db;

        public ArticleRepository(AppDbContext db) : base(db)
        {
           this.db = db;
        }

        public IEnumerable<Article> GetAllIncludeCategory()
        {
            return db.Articles.Include(a => a.Categories);
        }

        public IEnumerable<Article> GetFavoriteCategoryOfArticle(int categoryId)
        {
            var categories = db.Categories.Include(a => a.Id == categoryId);
            return db.Articles.Include(a => a.Categories == categories);
        }

        public IEnumerable<Article> GetMostViewedArticleByViewCount()
        {
            return db.Articles.OrderByDescending(a => a.ViewCount);
        }
    }
}
