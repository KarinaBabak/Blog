using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

using Blog.DAL.Entities;

namespace ORM.Configuration
{
    public class RoleConfiguration: EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            this.Property(n => n.Name).IsRequired();
            this.HasMany(r => r.RolesUser).WithRequired(r => r.Role).HasForeignKey(r => r.RoleId);
        }
    }
}
