using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Interface.DTO
{
    public class DalSection: IEntity
    {        
        public int Id { get; set; }        
        public string Name { get; set; }        
    }
}
