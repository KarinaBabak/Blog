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
    public class TagController : Controller
    {
        private readonly ITagService service;

        public TagController(ITagService tagService)
        {
            service = tagService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetTagsOfArticle(int articleId)
        {
            var tags = service.GetTagsOfArticle(articleId);
            return PartialView("TagsOfArticle", tags.Select(t => t.ToModelTag()));
        }

        [HttpGet]
        public ActionResult GetTagById(int tagId)
        {
            var tag = service.GetTagEntityById(tagId).ToModelTag();
            return PartialView("NameTagById", tag);
        }

    }
}
