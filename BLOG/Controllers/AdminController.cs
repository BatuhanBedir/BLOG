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

        public AdminController(IAppUserRepository appUserRepository, IArticleRepository articleRepository, ICategoryRepository categoryRepository)
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
            //all users list
            appUserIndexVM.AppUsers = appUserRepository.GetAll();

            return View(appUserIndexVM);
        }
        public IActionResult ArticleRemove()
        {
            ArticleIndexVM articleIndexVM = new ArticleIndexVM();
            //all articles list
            articleIndexVM.Articles = articleRepository.GetAll();//onay?

            return View(articleIndexVM);
        }
        public IActionResult DeleteArticle(int Id)
        {
            var article = articleRepository.GetById(Id);
            if (article != null)
            {
                bool returner = articleRepository.Delete(article);
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult DeleteUser(string Id)
        {
            var user = appUserRepository.GetById(Id);
            if (user != null)
            {
                bool returner = appUserRepository.Delete(user);
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult AddCategory()
        {
            var category = categoryRepository.GetAll();   
            if (category!=null)
            {
                CategoryIndexVM categoryIndexVM = new CategoryIndexVM();
                //all categories list
                categoryIndexVM.Categories = categoryRepository.GetAll();
                return View(categoryIndexVM); 
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult AddCategory(CategoryIndexVM categoryIndexVM)
        {
            if (!ModelState.IsValid)
            {
                categoryIndexVM.Categories = categoryRepository.GetAll();
                return View(categoryIndexVM);
            }
            Category category = new Category();
            category.Name = categoryIndexVM.CategoryName;
            //categoryRepository.Add(category);
            return RedirectToAction(nameof(AddCategory));
        }

        public IActionResult RemoveCategory(int id)
        {
            var category = categoryRepository.GetById(id);
            if (category !=null)
            {
                bool returner = categoryRepository.Delete(category);
            }
            return RedirectToAction("AddCategory", "Admin");
        }
    }
}
