using BLOG.Areas.Identity.Data;
using BLOG.Entities.Concrete;
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
        private readonly IAppUserRepository appUserRepository;
        public UserController(IArticleRepository articleRepository, UserManager<AppUser> userManager, IAppUserRepository appUserRepository)
        {
            this.articleRepository = articleRepository;
            this.userManager = userManager;
            this.appUserRepository = appUserRepository;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddArticle()
        {
            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            AppUser user = appUserRepository.GetById(userID);
            ArticleUserVM articleUserVM = new ArticleUserVM();
            articleUserVM.UserId = userID;
            return View(articleUserVM);
        }

        /// <summary>
        /// Add Article by user
        /// </summary>
        /// <param name="articleUserVM"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddArticle(ArticleUserVM articleUserVM)
        {
            Article article = new Article();
            article.Title = articleUserVM.Title;
            article.Content = articleUserVM.Content;
            article.AppUserId = articleUserVM.UserId;
            articleRepository.Add(article);

            return RedirectToAction("Index","Home");
        }
    }
}
