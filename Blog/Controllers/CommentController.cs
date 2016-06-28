using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Blog.ViewModels;
using Blog.Models;
using Blog.BLL.Interface.Services;
using Blog.Providers;
using Blog.Mappers;

namespace Blog.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;
        private readonly IUserService userService;

        public CommentController(ICommentService commentService, IUserService userService)
        {
            this.commentService = commentService;
            this.userService = userService;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult AddComment()
        {
            return PartialView("_CommentCreate");
        }

        [HttpPost]
        public ActionResult AddComment(CommentViewModel model, int articleId)
        {            
            model.DatePublication = DateTime.Now;
            model.SenderId = Convert.ToInt32(HttpContext.Profile.GetPropertyValue("Id"));
            model.ArticleId = articleId;
            commentService.CreateComment(model.ToBllComment());
           
            return GetCommentsOfArticle(model.ArticleId);
        }

        /// <summary>
        /// Getting all comments of article
        /// </summary>
        /// <param name="articleId">id of article</param>
        /// <returns></returns>
        [HttpGet]        
        public ActionResult GetCommentsOfArticle(int articleId)
        {
            var comments = commentService.GetByArticle(articleId).Select(c=>c.ToModelComment());            
            return PartialView("_CommentsOfArticle", GetCommentModels(comments));
        }

        [HttpPost]
        public ActionResult DeleteComment(int articleId, int commentId)
        {
            commentService.DeleteComment(commentService.GetCommentEntityById(commentId));
            var comments = commentService.GetByArticle(articleId).Select(c=>c.ToModelComment());            
            return PartialView("_CommentsOfArticle", GetCommentModels(comments));
        }

        private IEnumerable<CommentModel> GetCommentModels(IEnumerable<CommentModel> comments)
        {
            if (comments == null) return null;
            List<CommentModel> models = new List<CommentModel>();
            foreach (var comment in comments)
            {               
                comment.Sender = userService.GetUserEntityById(comment.SenderId).ToModelUser();
                models.Add(comment);
            }
            return models;
        }


    }
}
