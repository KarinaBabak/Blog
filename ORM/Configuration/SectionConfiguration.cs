using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

using Blog.DAL.Entities;

namespace ORM.Configuration
{
    public class SectionConfiguration: EntityTypeConfiguration<Section>
    {
        public SectionConfiguration()
        {
            this.Property(n => n.Name).IsRequired();
            this.HasMany(a => a.Articles).WithRequired(a => a.Section).HasForeignKey(k => k.SectionId);
        }
    }
}
