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
        private readonly IArticleRepository _articleRepository;

        public ArticleByCategoriesController(ILogger<UsersArticleController> logger, IArticleRepository articleRepository)
        {
            _logger = logger;
            _articleRepository = articleRepository;
        }

        public IActionResult Index()
        {
            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userID == null)
            {
                return LocalRedirect("~/Identity/Account/Register");
            }
            var articles = _articleRepository.GetFavoriteCategoryOfArticle(userID);
            ArticleIndexVM articleIndexVM = new ArticleIndexVM();
            articleIndexVM.Articles = articles;
            return View(articleIndexVM);
        }
    }
}
