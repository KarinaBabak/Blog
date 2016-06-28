using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Blog.DAL.Entities;

using ORM.Configuration;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ORM
{
    public partial class BlogModel : DbContext
    {
        public BlogModel():
            base("name=BlogModel")
        {
        }

        #region 
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoleUser> RolesUser { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Marker> Markers { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<TagArticle> TagsArticle { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {            
            base.OnModelCreating(modelBuilder);
           
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new SectionConfiguration());
            modelBuilder.Configurations.Add(new ArticleConfiguration());
            modelBuilder.Configurations.Add(new TagConfiguration());
            modelBuilder.Configurations.Add(new CommentConfiguration());
        }

    }
}
