using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Blog.DAL.Interface.Interface;
using Blog.DAL.Interface.DTO;
using Blog.DAL.Entities;

namespace DAL.Concrete
{
    public class TagRepository: ITagRepository
    {
        private readonly DbContext context;
        public TagRepository(DbContext dbContext)
        {
            context = dbContext;
        }

        /// <summary>
        /// Getting all tags
        /// </summary>
        /// <returns>an enumeration of all tags</returns>
        public IEnumerable<DalTag> GetAll()
        {
            return context.Set<Tag>().Select(tag => new DalTag()
            {
                Id = tag.Id,
                Name = tag.Name                
            });
        }

        /// <summary>
        /// Get tag by id
        /// </summary>
        /// <param name="tagId">id of tag</param>
        /// <returns></returns>
        public DalTag GetById(int tagId)
        {
            var tag = context.Set<Tag>().Where(t => t.Id == tagId).FirstOrDefault();
            return new DalTag()
            {
                Id = tag.Id,
                Name = tag.Name
            };
        }

        /// <summary>
        /// Adding tag
        /// </summary>
        /// <param name="entity">tag for adding</param>
        public void Create(DalTag entity)
        {
            var tag = new Tag()
            {
                Id = entity.Id,
                Name = entity.Name
            };
            context.Set<Tag>().Add(tag);
            context.SaveChanges();
        }

        /// <summary>
        /// Determination of removing of tag
        /// </summary>
        /// <param name="entity">tag to delete</param>
        public void Delete(DalTag entity)
        {
            var tag = context.Set<Tag>().Where(t => t.Id == entity.Id).FirstOrDefault();
            if (tag != null)
            {
                context.Set<Tag>().Remove(tag);
            }
        }

        /// <summary>
        /// Update information about tag
        /// </summary>
        /// <param name="entity">tag</param>
        public void Update(DalTag entity)
        {
            var tag = context.Set<Tag>().Where(t => t.Id == entity.Id).FirstOrDefault();
            if (tag != null)
            {
                tag.Id = entity.Id;
                tag.Name = entity.Name;
            }
        }

        public IEnumerable<DalTag> GetTagsOfArticle(int articleId)
        {
            var tags = from t in context.Set<Tag>()
                       join ta in context.Set<TagArticle>()
                       on t.Id equals ta.TagId
                       where ta.ArticleId == articleId
                       select t;
            
            if (tags != null) return tags.Select(a => new DalTag() { Id = a.Id, Name = a.Name });                
            return null;
        }
    }
}
