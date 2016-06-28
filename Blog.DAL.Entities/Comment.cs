using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.DAL.Entities
{
    public class Comment : IEntity, IMessage
    {
        public int Id { get; set; }        
        public string Content { get; set; }
        public DateTime DatePublication { get; set; }
        public int SenderId { get; set; }
        public int ArticleId { get; set; }
        public int RateUsefulComment { get; set; }
        public virtual User Sender { get; set; }
        public virtual Article Article { get; set; }        
    }
}
