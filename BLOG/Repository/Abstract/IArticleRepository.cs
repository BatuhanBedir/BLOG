using BLOG.Entities.Concrete;

namespace BLOG.Repository.Abstract
{
    public interface IArticleRepository : IRepository<Article>
    {
        public Article GetById(int id);
        List<Article> GetAllIncludeCategory();
        List<Article> GetMostViewedArticleByViewCount();
        List<Article> GetFavoriteCategoryOfArticle(string appUserId);
        List<Article> GetArticlesBySelectedUserId(string id);
    }
}
