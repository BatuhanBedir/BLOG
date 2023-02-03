using BLOG.Models;
using BLOG.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BLOG.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleRepository articleRepository;

        public HomeController(ILogger<HomeController> logger,IArticleRepository articleRepository)
        {
            _logger = logger;
            this.articleRepository = articleRepository;
        }

        public IActionResult Index()
        {
            var articles = articleRepository.GetMostViewedArticleByViewCount();
            ArticleIndexVM articleIndexVM = new ArticleIndexVM();
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