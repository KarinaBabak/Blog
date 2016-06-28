using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class CommentModel
    {
        public int Id { get; set; }        
        public string Content { get; set; }        
        public int ArticleId { get; set; }       
        public DateTime DatePublication { get; set; }
        public int SenderId { get; set; }
        public UserModel Sender { get; set; }
    }
}