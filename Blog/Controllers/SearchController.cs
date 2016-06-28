using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Blog.Models;
using Blog.BLL.Interface.Services;
using System.Web.Security;
using Blog.Providers;
using Blog.Mappers;

namespace Blog.Controllers
{
    public class SearchController : Controller
    {
        private readonly IArticleService articleService;
        private readonly IUserService userService;

        public SearchController(IArticleService articleService, IUserService userService)
        {
            this.articleService = articleService;
            this.userService = userService;
        }

        [ChildActionOnly]
        public ActionResult Index()
        {
            return PartialView("~/Views/Shared/_Search.cshtml");
        }

        [HttpPost]
        public ActionResult SearchJson(SearchViewModel model)
        {
            var result = articleService.Search(model.SearchString).Select(r => r.ToViewModelArticle());
            if(result.ToArray().Length == 0)
            {
                return new JsonResult()
                {
                    Data = new
                    {
                        message = "Ничего не найдено"
                    }
                };
            }
            return Json(result);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Search(SearchViewModel model)
        {
            List<ArticleModel> list = new List<ArticleModel>();
            var result = articleService.Search(model.SearchString).Select(r => r.ToModelArticle());
            foreach(var article in result)
            {                
                article.Blogger = userService.GetUserEntityById(article.BloggerId).ToModelUser();
                list.Add(article);
            }
            
            ViewBag.QuerySearch = model.SearchString;

            return View(list);
        }

        [HttpGet]
        public ActionResult Search()
        {
            return RedirectToAction("Index", "Home");
        }

        

    }
}
