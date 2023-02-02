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
            throw new NotImplementedException();
        }

        public IEnumerable<Article> GetFavoriteCategoryOfArticle(int categoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Article> GetMostViewedArticleByViewCount()
        {
            throw new NotImplementedException();
        }
    }
}
