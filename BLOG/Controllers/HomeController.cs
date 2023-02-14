using BLOG.Models;
using BLOG.Repository.Abstract;
using BLOG.Repository.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace BLOG.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleRepository articleRepository;
        private readonly ICategoryRepository categoryRepository;

        public HomeController(ILogger<HomeController> logger,IArticleRepository articleRepository,ICategoryRepository categoryRepository)
        {
            _logger = logger;
            this.articleRepository = articleRepository;
            this.categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            ArticleIndexVM articleIndexVM = new ArticleIndexVM();

            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //if (userID != null)
            //{
            //    var articleList = articleRepository.GetFavoriteCategoryOfArticle(userID);
            //    articleIndexVM.Articles = articleList;
            //    return RedirectToRoute(new { controller = "ArticleByCategories", action="Index"});
            //}
            //if (userID!=null)
            //{
            //    return View("Index", "UsersArticleController");
            //}
            var articles = articleRepository.GetMostViewedArticleByViewCount();
            articleIndexVM.Articles = articles;

            return View(articleIndexVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}