using BLOG.Entities.Concrete;
using BLOG.Models;
using BLOG.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BLOG.Controllers
{
    [Route("articleByCategories")]
    public class ArticleByCategoriesController : Controller
    {
        private readonly ILogger<UsersArticleController> _logger;
        private readonly IArticleRepository articleRepository;
        private readonly IAppUserRepository appUserRepository;

        public ArticleByCategoriesController(ILogger<UsersArticleController> logger, IArticleRepository articleRepository,IAppUserRepository appUserRepository)
        {
            _logger = logger;
            this.articleRepository = articleRepository;
            this.appUserRepository = appUserRepository;
        }

        public IActionResult Index()
        {
            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userID == null)
            {
                return LocalRedirect("~/Identity/Account/Register");
            }

            var user = appUserRepository.GetByIdIncludeCategory(userID);
            var categories = user.Category;
            List<Article> articleList = new List<Article>();

            foreach (var item in categories)
            {
                var articles = articleRepository.CategoryInclude(item.Id);
                foreach (var item1 in articles)
                {
                    if (!articleList.Any(a=>a.Id==item1.Id))
                    {
                        articleList.Add(item1);
                    }
                }
            }
            //var articles = _articleRepository.GetFavoriteCategoryOfArticle(userID);
            ArticleIndexVM articleIndexVM = new ArticleIndexVM();
            articleIndexVM.Articles = articleList;
            return View(articleIndexVM);
        }
    }
}
