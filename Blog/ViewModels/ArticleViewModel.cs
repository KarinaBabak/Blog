using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class ArticleViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name="Заголовок статьи:")]
        [MaxLength(400, ErrorMessage = "Длинное название статьи")]    
        public string Title { get; set; }

        [Display(Name="Содержимое статьи:")]
        public string Content { get; set; }

        [Display(Name = "Теги к статье:")]
        public string Tags { get; set; }

        [DataType(DataType.Date)]
        public DateTime DatePublication { get; set; }

        public int BloggerId { get; set; }
        public int SectionId { get; set; }
        public int CountLikes { get; set; }
        public int CountShows { get; set; }
    }
}