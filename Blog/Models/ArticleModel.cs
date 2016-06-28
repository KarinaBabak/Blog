using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class ArticleModel
    {      
        public int Id { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public DateTime DatePublication { get; set; }
        public UserModel Blogger { get; set; }
        public int BloggerId { get; set; }
        public int SectionId { get; set; }
        public int CountLikes { get; set; }
        public int CountShows { get; set; }
        
        public IEnumerable<string> Tags { get; set; }


    }
}