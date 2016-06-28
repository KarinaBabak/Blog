using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class SearchViewModel
    {
        [MinLength(2, ErrorMessage="Слишком короткое слово")]
        public string SearchString { get; set; }
    }
}