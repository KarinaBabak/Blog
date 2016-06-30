using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Blog.Models;
using Blog.BLL.Interface.Services;
using Blog.Providers;
using Blog.Mappers;

namespace Blog.Controllers
{
    public class SectionController : Controller
    {
        private readonly ISectionService sectionService;
        private readonly IArticleService articleService;

        public SectionController(ISectionService sectionService, IArticleService articleService)
        {
            this.sectionService = sectionService;
            this.articleService = articleService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ShowAllSections()
        {            
            AllSectionsViewModel sections = new AllSectionsViewModel()
            {
                SectionId = 0,
                Sections = sectionService.GetAllSectionEntities()
            };
           
            return PartialView("ShowAllSections", sections);
        }
    
        [HttpGet]
        public ActionResult WorkWithSections()
        {
            var sections = sectionService.GetAllSectionEntities().Select(s=>s.ToViewModelSection());
            return View("WorkWithSections", sections);
        }

        [HttpGet]
        public ActionResult DeleteSection(int sectionId)
        {
            var anyArticle = articleService.GetArticleEntityBySection(sectionId).Any();
            if (!anyArticle)
            {
                sectionService.DeleteSection(sectionService.GetSectionEntityById(sectionId));
            }
            return RedirectToAction("WorkWithSections", "Section");
        }

       
        [HttpPost]
        public ActionResult AddSection(SectionViewModel model)
        {
            sectionService.CreateSection(model.ToBllSection());
            return RedirectToAction("WorkWithSections", "Section");
        }

        [HttpGet]
        public ActionResult AllArticlesBySections()
        {
            var allSections = sectionService.GetAllSectionEntities().Select(s=>s.ToModelSection());
            List<SectionModel> models = new List<SectionModel>();
            foreach(var section in allSections)
            {
                section.Articles = articleService.GetArticleEntityBySection(section.Id).Select(a=>a.ToModelArticle());
                models.Add(section);                
            }
            return View(models);
        }

    }
}
