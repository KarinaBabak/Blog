using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Interface.DTO
{
    public class DalUser:IEntity
    {
        public int Id { get; set; }        
        public string Login { get; set; }
        public string Password { get; set; }        
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public byte[] Photo { get; set; }
        public string AdditionalInfo { get; set; }
        public bool IsBlocked { get; set; }
        public DateTime DateRegistration { get; set; }
        public DateTime? DateLastVisit { get; set; }
    }
}
