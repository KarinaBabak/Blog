using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

using Blog.DAL.Entities;

namespace ORM.Configuration
{
    public class UserConfiguration:EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            this.Property(l => l.Login).IsRequired();
            this.Property(p => p.Password).IsRequired();
            this.Property(e => e.Email).IsRequired();
            this.Property(d => d.DateRegistration).HasColumnType("datetime2");            
            this.HasMany(a => a.Articles).WithRequired(a => a.Blogger).
                HasForeignKey(a => a.BloggerId).WillCascadeOnDelete(false);
            this.HasMany(m => m.Markers).WithRequired(m => m.User).HasForeignKey(m => m.UserId).WillCascadeOnDelete(false);
            this.HasMany(c => c.Comments).WithRequired(c => c.Sender).HasForeignKey(c => c.SenderId).WillCascadeOnDelete(false);
            this.HasMany(r => r.RolesUser).WithRequired(r => r.User).HasForeignKey(r => r.UserId).WillCascadeOnDelete(false);
        }
    }
}
