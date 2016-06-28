using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels
{
    public class CommentViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Сообщение")]
        public string Content { get; set; }

        [Required]
        public int ArticleId { get; set; }

        [DataType(DataType.Date)]
        public DateTime DatePublication { get; set; }

        public int SenderId { get; set; }
    }
}