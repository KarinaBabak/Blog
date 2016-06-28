using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Interface.DTO
{
    public class DalComment: IEntity
    {
        public int Id { get; set; }        
        public string Content { get; set; }
        public DateTime DatePublication { get; set; }
        public int SenderId { get; set; }
        public int ArticleId { get; set; }
        public int RateUsefulComment { get; set; }
    }
}
