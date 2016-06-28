using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.Interface.Entities
{
    public class TagArticleEntity
    {
        public int Id { get; set; }
        public int TagId { get; set; }
        public int ArticleId { get; set; }
    }
}
