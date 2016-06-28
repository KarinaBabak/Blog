using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class TagViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [MaxLength(40, ErrorMessage = "Длинное название тега")]
        public string Name { get; set; }

        
    }
}