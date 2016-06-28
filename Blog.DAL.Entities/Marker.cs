using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Entities
{
    public class Marker: IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ArticleId { get; set; }

        public virtual User User { get; set; }
        public virtual Article Article { get; set; }
    }
}
