using BLOG.Entities.Concrete;
using BLOG.Models;
using BLOG.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BLOG.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAppUserRepository appUserRepository;
        private readonly IArticleRepository articleRepository;
        private readonly ICategoryRepository categoryRepository;

        public AdminController(IAppUserRepository appUserRepository,IArticleRepository articleRepository,ICategoryRepository categoryRepository)
        {
            this.appUserRepository = appUserRepository;
            this.articleRepository = articleRepository;
            this.categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UserRemove()
        {
            AppUserIndexVM appUserIndexVM = new AppUserIndexVM();
            appUserIndexVM.AppUsers = appUserRepository.GetAll();

            return View(appUserIndexVM);
        }
        public IActionResult ArticleRemove()
        {
            ArticleIndexVM articleIndexVM = new ArticleIndexVM();
            articleIndexVM.Articles = articleRepository.GetAll();
            
            return View(articleIndexVM);
        }
        public IActionResult DeleteArticle(int Id)
        {
            var article = articleRepository.GetById(Id);
            if (article != null)
            {
                bool returner = articleRepository.Delete(article);
            }
            return RedirectToAction("Index","Home");
        }
        public IActionResult DeleteUser(string Id)
        {
            var user = appUserRepository.GetById(Id);
            if (user!=null)
            {
                bool returner = appUserRepository.Delete(user);
            }
            return RedirectToAction("Action", "Home");
        }
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(CategoryIndexVM categoryIndexVM)
        {
            Category category = new Category();
            category.Name = categoryIndexVM.CategoryName;
            categoryRepository.Add(category);
            return RedirectToAction(nameof(AddCategory));
        }
    }
}
