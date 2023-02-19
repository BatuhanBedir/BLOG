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
            return db.Articles.Include(a => a.Categories).ToList();
        }

        public Article GetById(int id)
        {
            return db.Set<Article>().FirstOrDefault(a => a.Id == id);
        }

        /// <summary>
        /// her bir Article nesnesinin Categories özelliğinde (bilgileri) aranan kategori id olan herhangi bir kategori varsa, o Article nesnesini seçer.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Category özelliği dahil edilmiş Article </returns>
        public IEnumerable<Article> CategoryInclude(int id)
        {
            return db.Articles.Include(q => q.Categories).Where(a => a.Categories.Any(c => c.Id == id));
        }
        

        //public IEnumerable<Article> GetFavoriteCategoryOfArticle(string appUserId)
        //{
        //    var user = db.Set<AppUser>().Include(q => q.Category).FirstOrDefault(a => a.Id == appUserId);
        //    var categories = user.Category;
        //    List<Article> articleList = new List<Article>();

        //    foreach (var item in categories)
        //    {
        //        var articles = db.Articles.Include(q => q.Categories).Where(a => a.Categories.Any(c => c.Id == item.Id));

        //        foreach (var article in articles)
        //        {
        //            if (!articleList.Any(a => a.Id == article.Id))
        //            {
        //                articleList.Add(article);
        //            }
        //        }
        //    }
        //    return articleList;
        //}

        /// <summary>
        /// Okunma sayısı çoktan aza doğru makaleleri getirir
        /// </summary>
        /// <returns>IEnumerable<Article></returns>
        public IEnumerable<Article> GetMostViewedArticleByViewCount()
        {
            return db.Articles.OrderByDescending(a => a.ViewCount).ToList();
        }

        /// <summary>
        /// gönderilmiş olan user id ye göre articleları gelecek
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Article> GetArticlesBySelectedUserId(string id)
        {
            return db.Articles.Where(q => q.AppUserId == id).ToList();
        }

        public Article GetByIdIncludeCategory(int id)
        {
            return db.Articles.Include(a => a.Categories).FirstOrDefault(a => a.Id == id);
        }

        public dynamic GetArticlesBySelectedUserId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Article> GetFavoriteCategoryOfArticle(string appUserId)
        {
            throw new NotImplementedException();
        }
    }
}
