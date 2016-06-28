using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.Interface.Entities
{
    public class ArticleEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DatePublication { get; set; }
        public int SectionId { get; set; }
        public int BloggerId { get; set; }
        public int CountLikes { get; set; }
        public int CountShows { get; set; }
    }
}
