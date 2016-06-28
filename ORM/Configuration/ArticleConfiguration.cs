using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

using Blog.DAL.Entities;

namespace ORM.Configuration
{
    public class ArticleConfiguration:EntityTypeConfiguration<Article>
    {
        public ArticleConfiguration()
        {
            this.Property(d => d.DatePublication).HasColumnType("datetime2");
            this.Property(t => t.Title).IsRequired();
            this.Property(c => c.Content).IsRequired();
            this.HasMany(c => c.Comments).WithRequired(c => c.Article).
                HasForeignKey(k=>k.ArticleId).WillCascadeOnDelete(false);
            this.HasMany(m => m.Markers).WithRequired(m => m.Article).HasForeignKey(k=>k.ArticleId);
            this.HasMany(a => a.TagsArticle).WithRequired(a => a.Article).HasForeignKey(k => k.ArticleId);                     
        }
    }
}
