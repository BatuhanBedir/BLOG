using BLOG.Areas.Identity.Data;
using BLOG.Entities.Concrete;
using BLOG.Models;
using BLOG.Repository.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Signing;
using System.Security.Claims;

namespace BLOG.Controllers
{
    public class UserController : Controller
    {
        private readonly IArticleRepository articleRepository;
        private readonly UserManager<AppUser> userManager;
        private readonly IAppUserRepository appUserRepository;

        private readonly ICategoryRepository categoryRepository;
        public UserController(IArticleRepository articleRepository, UserManager<AppUser> userManager, IAppUserRepository appUserRepository,ICategoryRepository categoryRepository)
        {
            this.articleRepository = articleRepository;
            this.userManager = userManager;
            this.appUserRepository = appUserRepository;

            this.categoryRepository = categoryRepository;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult ListArticle()
        {
            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user=appUserRepository.GetById(userID);
            ArticleUserVM articleUserVM = new ArticleUserVM();
            articleUserVM.Articles = user.Articles;
            return View(articleUserVM);
        }
        public IActionResult AddArticle()
        {
            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var category = categoryRepository.GetAll();
            if(userID == null)
            {
                return LocalRedirect("~/Identity/Account/Register");
            }
            AppUser user = appUserRepository.GetById(userID);
            ArticleUserVM articleUserVM = new ArticleUserVM();
            articleUserVM.UserId = userID;
            articleUserVM.Categories = category;
            return View(articleUserVM);
        }

        /// <summary>
        /// Add Article by user
        /// </summary>
        /// <param name="articleUserVM"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddArticle(ArticleUserVM articleUserVM, int[]ids)
        {
            Article article = new Article();
            article.Title = articleUserVM.Title;
            article.Content = articleUserVM.Content;
            article.AvgReadingTime = article.Content.Length / 200;
            article.AppUserId = articleUserVM.UserId;

            List<Category> categories = new List<Category>();
            foreach (var item in ids)
            {
                var category = categoryRepository.GetById(item);
                categories.Add(category);
            }

            article.Categories = categories;
            articleRepository.Add(article);

            return RedirectToAction("Index","Home");
        }
        public IActionResult SelectCategories() 
        {
            var categories = categoryRepository.GetAll();
            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userID == null)
            {
                return LocalRedirect("~/Identity/Account/Register");
            }
            ViewBag.CategoryUser = appUserRepository.GetByIdIncludeCategory(userID);
            UserCategoryVM userCategoryVM = new UserCategoryVM()
            {
                Categories = categories,
                UserId = userID
            };
            return View(userCategoryVM);
        }
        [HttpPost]
        public IActionResult SelectCategories(string Id,int[] ids)
        {
            AppUser appUser = new AppUser();
            appUser = appUserRepository.GetByIdIncludeCategory(Id);
            HashSet<Category> categories = new HashSet<Category>();

            foreach (var item in ids)
            {
                var category = categoryRepository.GetById(item);
                categories.Add(category);
            }
            appUser.Category=categories;
            var returner = appUserRepository.Update(appUser);
            return RedirectToAction("SelectCategories");
        }

        public IActionResult EditUser()
        {
            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = appUserRepository.GetById(userID);

            return View();
        }
        public IActionResult EditArticle()
        {
            return View();
        }
    }
}
