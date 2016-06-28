using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

using Blog.Models;
using Blog.ViewModels;
using Blog.BLL.Interface.Services;
using Blog.Providers;
using Blog.Mappers;


namespace Blog.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService articleService;
        private readonly IUserService userService;

        public ArticleController(IArticleService articleService, IUserService userService)
        {
            this.articleService = articleService;
            this.userService = userService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateArticle()
        {            
            return View();
        }

        /// <summary>
        /// Creating the article
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateArticle(ArticleViewModel model)
        {
            model.DatePublication = DateTime.Now;
            model.CountShows = 0;
            model.CountLikes = 0;            
            model.BloggerId = Convert.ToInt32(HttpContext.Profile.GetPropertyValue("Id"));
            articleService.CreateArticle(model.ToBllArticle());
            var articles = articleService.GetAllArticleEntities().Where(a=>a.Title == model.Title && a.DatePublication == model.DatePublication).FirstOrDefault();
            TagHelper.CreateArticle(model.Tags, articles.Id);
            
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Viewing preview of last 10 articles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult TopPreViewArticle()
        {
            var articles = articleService.GetAllArticleEntities().OrderByDescending(a => a.DatePublication).Take(10).
                Select(a => a.ToModelArticle());

            List<ArticleModel> models = new List<ArticleModel>();
            foreach(var article in articles)
            {
                article.Blogger = userService.GetUserEntityById(article.BloggerId).ToModelUser();
                models.Add(article);
            }

            return PartialView(models);
        }

        /// <summary>
        /// Show preview of article
        /// </summary>
        /// <param name="articleId">id of article</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult PreViewArticle(int articleId)
        {
            var article =  articleService.GetArticleEntityById(articleId).ToModelArticle();
            article.Blogger = userService.GetUserEntityById(article.BloggerId).ToModelUser();
            return PartialView(article);
        }

        /// <summary>
        /// Viewing full article
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult ViewArticle(int articleId)
        {           
            var article = articleService.GetArticleEntityById(articleId).ToModelArticle();
            article.CountShows+=1;
            article.Blogger = userService.GetUserEntityById(article.BloggerId).ToModelUser();
            articleService.UpdateArticle(article.ToBllArticle());
            return View(article);
        }

        /// <summary>
        /// Searching by tag
        /// </summary>
        /// <param name="tagId">tag id</param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult SearchByTag(int tagId)
        {
            var articles = articleService.GetArticleEntityByTag(tagId).Select(a=>a.ToModelArticle());

            List<ArticleModel> models = new List<ArticleModel>();
            foreach (var article in articles)
            {
                article.Blogger = userService.GetUserEntityById(article.BloggerId).ToModelUser();
                models.Add(article);
            }
            ViewBag.TagId = tagId;
            return View("SearchByTag", models);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult ViewArticlesOfBlogger(int bloggerId)
        {
            var articles = articleService.GetByBloggerId(bloggerId).Select(a=>a.ToModelArticle());
            List<ArticleModel> models = new List<ArticleModel>();
            foreach (var article in articles)
            {
                article.Blogger = userService.GetUserEntityById(article.BloggerId).ToModelUser();
                models.Add(article);
            }
            return View("ArticlesOfBlogger", models);
        }

        [HttpGet]
        public ActionResult UpdateArticle(int articleId)
        {
            var article = articleService.GetArticleEntityById(articleId).ToViewModelArticle();
            
            return View(article);
        }

        [HttpPost]
        public ActionResult UpdateArticle(ArticleViewModel model)
        {
            model.BloggerId = Convert.ToInt32(HttpContext.Profile.GetPropertyValue("Id"));            
            TagHelper.CreateArticle(model.Tags, model.Id);
            articleService.UpdateArticle(model.ToBllArticle());
            return ViewArticlesOfBlogger(model.BloggerId);
        }

        [HttpPost]
        public ActionResult DeleteArticle(int articleId, int bloggerId)
        {
            articleService.DeleteArticle(articleService.GetArticleEntityById(articleId));
            return ViewArticlesOfBlogger(bloggerId);
        }
           
        
    }
}
