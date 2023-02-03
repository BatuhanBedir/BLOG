using BLOG.Areas.Identity.Data;
using BLOG.Models;
using BLOG.Repository.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BLOG.Controllers
{
    public class UserController : Controller
    {
        private readonly IArticleRepository articleRepository;
        private readonly UserManager<AppUser> userManager;
        AppDbContext context;
        public UserController(IArticleRepository articleRepository,UserManager<AppUser> userManager)
        {
            this.articleRepository = articleRepository;
            this.userManager = userManager;
        }
        [Authorize]
        public IActionResult Index()
        {
            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ArticleUserVM articleUserVM = new ArticleUserVM();
            articleUserVM.UserId = userID;
            return RedirectToAction("AddArticle", articleUserVM);
        }

        public IActionResult AddArticle()
        {
            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ArticleUserVM articleUserVM = new ArticleUserVM();
            articleUserVM.UserId = userID;
            return View(articleUserVM);
        }
        //[HttpPost]
        //public IActionResult AddArticle(ArticleUserVM articleUserVM)
        //{
        //    AppUser appUser = new AppUser();
        //    appUser.Articles = (ICollection<Entities.Concrete.Article>?)articleUserVM.Articles;

        //    return RedirectToAction("AddArticle");
        //}
    }
}
