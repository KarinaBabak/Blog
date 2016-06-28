using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.DAL.Entities
{
    public class Section: IEntity
    {
        public Section()
        {
            Articles = new HashSet<Article>();
        }
        public int Id { get; set; }        
        public string Name { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
