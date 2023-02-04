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
            var article = articleRepository.GetById(Id);
            article.ViewCount++;
            articleRepository.Update(article);
            var users = appUserRepository.GetById(article.AppUserId);

            string writer = users.FirstName+ " " + users.LastName;

            ArticleIndexVM articleIndexVM = new ArticleIndexVM();
            articleIndexVM.Title = article.Title;
            articleIndexVM.Content = article.Content;
            articleIndexVM.ViewCount = article.ViewCount;
            articleIndexVM.Writer = writer;
            articleIndexVM.CreatedTime = article.CreatedDate;
            articleIndexVM.AvgReadingTime = article.AvgReadingTime;
            articleIndexVM.UserId = article.AppUserId;

            return View(articleIndexVM);
        }

    }
}
