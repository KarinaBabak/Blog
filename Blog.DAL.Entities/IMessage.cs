using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Entities
{
    public interface IMessage
    {
        string Content { get; set; }
        DateTime DatePublication { get; set; }
        //public int SenderId { get; set; }
    }
}
