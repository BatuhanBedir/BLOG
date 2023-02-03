using BLOG.Entities.Concrete;
using BLOG.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BLOG.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleRepository articleRepository;

        public ArticleController(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ArticleAdd(int Id)
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult ArticleAdd(Article article)
        {

            return View();
        }
    }
}
