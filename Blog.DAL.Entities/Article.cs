using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Entities
{
    public class Article: IEntity, IMessage
    {
        public Article()
        {
            Comments = new HashSet<Comment>();
            Markers = new HashSet<Marker>();
            TagsArticle = new HashSet<TagArticle>();
        }

        public int Id { get; set; }        
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DatePublication { get; set; }
        public int SectionId { get; set; }   
        public int BloggerId { get; set; }
        public int CountLikes { get; set; }
        public int CountShows { get; set; }

        public virtual Section Section { get; set; }
        public virtual User Blogger { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Marker> Markers { get; set; }
        public virtual ICollection<TagArticle> TagsArticle { get; set; }
    }
}
