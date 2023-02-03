using BLOG.Entities.Concrete;
using BLOG.Models;
using BLOG.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BLOG.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleRepository articleRepository;
        private readonly IAppUserRepository appUserRepository;

        public ArticleController(IArticleRepository articleRepository,IAppUserRepository appUserRepository)
        {
            this.articleRepository = articleRepository;
            this.appUserRepository = appUserRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ReadArticle(int Id)
        {
            var articles = articleRepository.GetById(Id);
            articles.ViewCount++;
            articleRepository.Update(articles);
            var users = appUserRepository.GetById(articles.AppUserId);

            string writer = users.FirstName+ " " + users.LastName;

            ArticleIndexVM articleIndexVM = new ArticleIndexVM();
            articleIndexVM.Title = articles.Title;
            articleIndexVM.Content = articles.Content;
            articleIndexVM.ViewCount = articles.ViewCount;
            articleIndexVM.Writer = writer;
            articleIndexVM.CreatedTime = articles.CreatedDate;
            articleIndexVM.AvgReadingTime = articles.AvgReadingTime;

            return View(articleIndexVM);
        }

    }
}
