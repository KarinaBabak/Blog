using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        #region Create
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
        [Authorize]
        public ActionResult CreateArticle(ArticleViewModel model)
        {
            model.DatePublication = DateTime.Now;
            model.CountShows = 0;
            model.CountLikes = 0;
            if (model.SectionId == 0)
            {
                model.SectionId = 1;
            }
            model.BloggerId = Convert.ToInt32(HttpContext.Profile.GetPropertyValue("Id"));
            articleService.CreateArticle(model.ToBllArticle());
            var article = articleService.GetAllArticleEntities().Where(a=>a.Title == model.Title && a.DatePublication == model.DatePublication).FirstOrDefault();
            TagHelper.CreateArticle(model.Tags, article.Id);

            return RedirectToAction("ViewArticle", "Article", new { articleId = article.Id });           
        }
        #endregion

        /// <summary>
        /// Viewing preview of last 10 articles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult TopPreViewArticle(int page = 1)
        {
            var articles = articleService.GetAllArticleEntities().OrderByDescending(a => a.DatePublication).
                Select(a => a.ToModelArticle());

            List<ArticleModel> models = new List<ArticleModel>();
            foreach(var article in articles)
            {
                article.Blogger = userService.GetUserEntityById(article.BloggerId).ToModelUser();
                models.Add(article);
            }

            int pageSize = 3;
            IEnumerable<ArticleModel> articleModels = models.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = models.Count };
            @ViewBag.PageInfo = pageInfo;
            return PartialView(articleModels);             
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
        public ActionResult SearchByTag(int tagId, int page = 1)
        {
            var articles = articleService.GetArticleEntityByTag(tagId).Select(a=>a.ToModelArticle());

            List<ArticleModel> models = new List<ArticleModel>();
            foreach (var article in articles)
            {
                article.Blogger = userService.GetUserEntityById(article.BloggerId).ToModelUser();
                models.Add(article);
            }
            ViewBag.TagId = tagId;

            int pageSize = 3;
            IEnumerable<ArticleModel> articleModels = models.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = models.Count() };
            @ViewBag.PageInfo = pageInfo;
            return View("SearchByTag", articleModels);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult ViewArticlesOfBlogger(int bloggerId)
        {
            var user = userService.GetUserEntityById(bloggerId);
            var articles = articleService.GetByBloggerId(bloggerId).OrderByDescending(a => a.DatePublication).Select(a=>a.ToModelArticle());
            List<ArticleModel> models = new List<ArticleModel>();
            foreach (var article in articles)
            {
                article.Blogger = userService.GetUserEntityById(article.BloggerId).ToModelUser();
                models.Add(article);
            }
            @ViewBag.BloggerLogin = user.Login;
            return View("ArticlesOfBlogger", models);
        }

        public ActionResult ShowPages(IEnumerable<ArticleModel> models, int page = 1)
        {            
            int pageSize = 3;
            IEnumerable<ArticleModel> articleModels = models.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = models.Count() };
            @ViewBag.PageInfo = pageInfo;
            return PartialView("TopPreViewArticle", articleModels);
        }

        #region Update
        [HttpGet]
        public ActionResult UpdateArticle(int articleId)
        {
            var article = articleService.GetArticleEntityById(articleId).ToViewModelArticle();            
            var tags = TagHelper.GetTagsOfArticle(articleId).ToArray();

            for (int i = 0; i < tags.Length - 1; i++ )
            {                
                    article.Tags += (tags[i] + ", ");
            }

            if (tags.Length > 0)  article.Tags += tags[tags.Length - 1];

            return View(article);
        }

        [HttpPost]
        [Authorize]
        public ActionResult UpdateArticle(ArticleViewModel model)
        {
            model.DatePublication = DateTime.Now;             
            TagHelper.DeleteTagArticle(model.Id);
            TagHelper.CreateArticle(model.Tags, model.Id);
            articleService.UpdateArticle(model.ToBllArticle());
            return RedirectToAction("ViewArticle", "Article", new { articleId = model.Id }); 
        }
        #endregion

        [HttpGet]
        public ActionResult DeleteArticle(int articleId, int bloggerId)
        {
            articleService.DeleteArticle(articleService.GetArticleEntityById(articleId));
            return ViewArticlesOfBlogger(bloggerId);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult ShowAllArticles()
        {
            //var allArticles = articleService.get
            return null;
        }
           
        
    }
}
