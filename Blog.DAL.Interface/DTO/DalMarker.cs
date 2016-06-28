using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Interface.DTO
{
    public class DalMarker:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ArticleId { get; set; }

    }
}
