using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

using Blog.DAL.Entities;

namespace ORM.Configuration
{
    public class TagConfiguration: EntityTypeConfiguration<Tag>
    {
        public TagConfiguration()
        {
            this.Property(n => n.Name).IsRequired().HasMaxLength(40);
            this.HasMany(a => a.TagsArticle).WithRequired(a => a.Tag).HasForeignKey(k => k.TagId);         
        }
    }
}
