using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.BLL.Interface.Entities;

namespace Blog.Models
{
    public class AllSectionsViewModel
    {
        public int SectionId { get; set; }
        public IEnumerable<SectionEntity> Sections { get; set; }
    }
}