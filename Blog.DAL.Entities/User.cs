using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Blog.DAL.Entities
{
    public class User: IEntity
    {
        public User()
        {
            Articles = new HashSet<Article>();
            Comments = new HashSet<Comment>();
            RolesUser = new HashSet<RoleUser>();
            Markers = new HashSet<Marker>();
        }

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

        #region Navigation Properties
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<RoleUser> RolesUser { get; set; }
        public virtual ICollection<Marker> Markers { get; set; }
        #endregion

    }
}
