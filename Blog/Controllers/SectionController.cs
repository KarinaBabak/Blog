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
        private readonly ISectionService service;

        public SectionController(ISectionService sectionService)
        {
            service = sectionService;
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
                Sections = service.GetAllSectionEntities()
            };
           
            return PartialView("ShowAllSections", sections);
        }

    }
}
