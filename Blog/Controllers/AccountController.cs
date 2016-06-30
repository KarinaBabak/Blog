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
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IUserService service;

        public AccountController(IUserService userService)
        {
            service = userService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel viewModel)
        {            
            if(String.IsNullOrEmpty(viewModel.Email))
            {
                ViewBag.Message = "Заполните все поля";
                return View(viewModel);
            }            
            viewModel.DateRegistration = DateTime.Now;
            var anyUser = service.GetAllUserEntities().Any(user => user.Email.Contains(viewModel.Email));
            if (anyUser)
            {
                ModelState.AddModelError("", "User with this address already registered.");
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                var membershipUser = ((CustomMembershipProvider)Membership.Provider)
                   .CreateUser(viewModel.ToBllUser());

                if (membershipUser != null)
                {
                    FormsAuthentication.SetAuthCookie(viewModel.Login, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Error registration.");
                }
            }
            return View(viewModel);
        }

        [AllowAnonymous]
        public ActionResult Login(string url)
        {
            var type = HttpContext.User.GetType();
            var iden = HttpContext.User.Identity.GetType();
            ViewBag.Url = url;            
            return View();
        }

      
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LogOnViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(viewModel.Login, viewModel.Password))
                {
                    FormsAuthentication.SetAuthCookie(viewModel.Login, viewModel.RememberMe);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Некорректный логин или пароль");
                }
            }
            return RedirectToAction("Login", "Account");
            
        }

        /// <summary>
        /// Log off
        /// </summary>
        /// <returns></returns>
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        [AllowAnonymous]
        [ChildActionOnly]
        public ActionResult GetBlogger(int senderId)
        {
            var user = service.GetUserEntityById(senderId);
            ViewBag.Id = senderId;
            return PartialView("Blogger", user.ToLogInModelUser());
        }

        [HttpGet]
        [AllowAnonymous]    
        public ActionResult GetBloggerProfile(string bloggerLogin)
        {
            var user = service.GetUserByLogin(bloggerLogin).ToModelUser();
            return View("Profile", user);
        }

        [HttpGet]
        public ActionResult EditBloggerProfile(int bloggerId)
        {
            var user = service.GetUserEntityById(bloggerId).ToModelUser();
            return View("EditProfile", user);
        }

        [HttpPost]
        public ActionResult EditBloggerProfile(UserModel model)
        {
            if (ModelState.IsValid)
            {                
                service.UpdateUser(model.ToBllUser());
            }
            return RedirectToAction("GetBloggerProfile", "Account", new { bloggerLogin = model.Login });
        }

        public void BlockUser(int bloggerId)
        {
            service.BlockUser(bloggerId);
        }

        public void UnBlockUser(int bloggerId)
        {
            service.UnBlockUser(bloggerId);
        }

        public bool IsBlocked(int bloggerId)
        {
            if (service.GetUserEntityById(bloggerId).IsBlocked == true) 
                return true;
            return false;
        }
    }
}
