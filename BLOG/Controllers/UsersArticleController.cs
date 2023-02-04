using BLOG.Entities.Concrete;
using BLOG.Models;
using BLOG.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BLOG.Controllers
{
    [Route("usersArticle")]
    public class UsersArticleController : Controller
    {
        private readonly ILogger<UsersArticleController> _logger;
        private readonly IArticleRepository _articleRepository;


        public UsersArticleController(ILogger<UsersArticleController> logger, IArticleRepository articleRepository)
        {
            _logger = logger;
            _articleRepository = articleRepository;
        }

        [Route("{userid}")]
        public IActionResult Index(string userid)
        {
            var usersArticle = _articleRepository.GetArticlesBySelectedUserId(userid);
            ArticleIndexVM articleIndexVM = new ArticleIndexVM();
            articleIndexVM.Articles = usersArticle;
            return View(articleIndexVM);
        }
    }
}
