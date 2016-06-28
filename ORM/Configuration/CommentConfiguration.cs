using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

using Blog.DAL.Entities;

namespace ORM.Configuration
{
    public class CommentConfiguration:EntityTypeConfiguration<Comment>
    {
        public CommentConfiguration()
        {           
            this.Property(d => d.DatePublication).HasColumnType("datetime2");
            this.Property(c => c.Content).IsRequired();
        }
    }
}
