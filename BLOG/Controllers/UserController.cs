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
        public UserController(IArticleRepository articleRepository, UserManager<AppUser> userManager, IAppUserRepository appUserRepository, ICategoryRepository categoryRepository)
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
            var user = appUserRepository.GetById(userID);
            var article = articleRepository.GetArticlesBySelectedUserId(userID);
            // List<Article> articles = new List<Article>();
            ArticleUserVM articleUserVM = new ArticleUserVM();
            articleUserVM.Articles = article;
            //foreach (var item in article)
            //{
            //    articleUserVM.Title = item.Title;
            //    articleUserVM.Content = item.Content;
            //    articleUserVM.CreatedDate = item.CreatedDate;
            //}


            return View(articleUserVM);
        }
        public IActionResult AddArticle(int id)
        {

            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            AppUser user = appUserRepository.GetById(userID);
            var allCategory = categoryRepository.GetAll();
            if (userID == null)
            {
                return LocalRedirect("~/Identity/Account/Register");
            }
            ArticleUserVM articleUserVM = new ArticleUserVM();

            ViewBag.ArticleCategory = articleRepository.GetByIdIncludeCategory(id);
            var article = articleRepository.GetById(id);
            //articleUserVM.Title = article.Title;
            //articleUserVM.Content = article.Content;
            //articleUserVM.CreatedDate = article.CreatedDate;
            //articleUserVM.Id = article.Id;
            articleUserVM.Categories = allCategory;


            var category = categoryRepository.GetAll();
            articleUserVM.UserId = userID;
            articleUserVM.Categories = category;


            return View(articleUserVM);
        }

        [HttpPost]
        public IActionResult AddArticle(ArticleUserVM articleUserVM, int[] ids)
        {
            //Article article = new Article();
            //article.Title = articleUserVM.Title;
            //article.Content = articleUserVM.Content;
            //article.AvgReadingTime = article.Content.Length / 200;
            //article.AppUserId = articleUserVM.UserId;

            //List<Category> categories = new List<Category>();
            //foreach (var item in ids)
            //{
            //    var category = categoryRepository.GetById(item);
            //    categories.Add(category);
            //}

            //article.Categories = categories;

            Article article = new Article();
            article.Title = articleUserVM.Title;
            article.Content = articleUserVM.Content;
            article.AvgReadingTime = article.Content.Length / 200;
            article.AppUserId = articleUserVM.UserId;

            HashSet<Category> categories = new HashSet<Category>();
            foreach (var item in ids)
            {
                var category = categoryRepository.GetById(item);
                categories.Add(category);
            }

            article.Categories = categories;
            articleRepository.Add(article);

            return RedirectToAction("Index", "Home");
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
        public IActionResult SelectCategories(string Id, int[] ids)
        {
            AppUser appUser = new AppUser();
            appUser = appUserRepository.GetByIdIncludeCategory(Id);
            HashSet<Category> categories = new HashSet<Category>();

            foreach (var item in ids)
            {
                var category = categoryRepository.GetById(item);
                categories.Add(category);
            }
            appUser.Category = categories;
            var returner = appUserRepository.Update(appUser);
            return RedirectToAction("SelectCategories");
        }

        public IActionResult EditUser()
        {
            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = appUserRepository.GetById(userID);

            return View();
        }
        public IActionResult EditArticle(int Id)
        {
            var allCategory = categoryRepository.GetAll();
            var article = articleRepository.GetById(Id);
            ViewBag.ArticleCategory = articleRepository.GetByIdIncludeCategory(Id);
            ArticleUserVM articleUserVM = new ArticleUserVM();
            articleUserVM.Title = article.Title;
            articleUserVM.Content = article.Content;
            articleUserVM.AvgReadingTime = article.AvgReadingTime;
            articleUserVM.CreatedDate = article.CreatedDate;
            articleUserVM.Categories = allCategory;
            articleUserVM.UserId = article.AppUserId;
            return View(articleUserVM);
        }
        [HttpPost]
        public IActionResult EditArticle(ArticleUserVM articleUserVM, int[] ids, int id)
        {
            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Article article = new Article();
            article = articleRepository.GetByIdIncludeCategory(id);
            article.Id = id;
            article.Title = articleUserVM.Title;
            article.Content = articleUserVM.Content;
            article.AvgReadingTime = articleUserVM.Content.Length / 200;
            article.AppUserId = userID;
            article.CreatedDate = DateTime.Now;

            HashSet<Category> categories = new HashSet<Category>();
            foreach (var item in ids)
            {
                var category = categoryRepository.GetById(item);
                categories.Add(category);
            }

            article.Categories = categories;
            articleRepository.Update(article);
            //Article article = new Article();
            //article.Title = editArticleVM.Title;
            //article.Content = editArticleVM.Content;
            //article.AvgReadingTime = editArticleVM.AvgReadingTime;
            //article.CreatedDate = editArticleVM.CreatedDate;
            //HashSet<Category> categories = new HashSet<Category>();
            //foreach (var item in ids)
            //{
            //    var category = categoryRepository.GetById(item);
            //    categories.Add(category);
            //}
            //article.Categories = categories;
            //article.AppUserId = editArticleVM.UserId;
            //var returner = articleRepository.Update(article);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Delete(int id)
        {
            var article = articleRepository.GetById(id);
            if (article!=null)
            {
                bool returner = articleRepository.Delete(article);
            }
            return RedirectToAction("ListArticle");
        }
        public IActionResult UserDetail(string id)
        {
            var user = appUserRepository.GetById(id);
            var articles = articleRepository.GetArticlesBySelectedUserId(id);
            UserDetailVM userDetailVM = new UserDetailVM();
            userDetailVM.FirstName = user.FirstName;
            userDetailVM.LastName = user.LastName;
            userDetailVM.Image = user.Image;
            userDetailVM.Description = user.Description;
            userDetailVM.Articles = (HashSet<Article>)user.Articles;

            return View(userDetailVM);
        }
    }
}
