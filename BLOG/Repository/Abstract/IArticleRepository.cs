using BLOG.Entities.Concrete;

namespace BLOG.Repository.Abstract
{
    public interface IArticleRepository : IRepository<Article>
    {
        public Article GetById(int id);
        IEnumerable<Article> GetAllIncludeCategory();
        IEnumerable<Article> GetMostViewedArticleByViewCount();
        IEnumerable<Article> GetFavoriteCategoryOfArticle(int categoryId);
    }
}
