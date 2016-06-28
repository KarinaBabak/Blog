using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Interface.DTO
{
    public class DalTagArticle: IEntity
    {
        public int Id { get; set; }
        public int TagId { get; set; }
        public int ArticleId { get; set; }
    }
}
