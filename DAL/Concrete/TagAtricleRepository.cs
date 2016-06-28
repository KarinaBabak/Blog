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
    public class TagAtricleRepository: ITagArticleRepository
    {
        private readonly DbContext context;
        public TagAtricleRepository(DbContext dbContext)
        {
            context = dbContext;
        }

        /// <summary>
        /// Getting all tags of all articles
        /// </summary>
        /// <returns>an enumeration of aall tags of all articless</returns>
        public IEnumerable<DalTagArticle> GetAll()
        {
            return context.Set<TagArticle>().Select(t => new DalTagArticle()
            {
                Id = t.Id,
                ArticleId = t.ArticleId,
                TagId = t.TagId
            });
        }

        /// <summary>
        /// Get tag and article by id
        /// </summary>
        /// <param name="entityId">id</param>
        /// <returns></returns>
        public DalTagArticle GetById(int entityId)
        {
            var tagArticle = context.Set<TagArticle>().Where(t => t.Id == entityId).FirstOrDefault();
            return new DalTagArticle()
            {
                Id = tagArticle.Id,
                ArticleId = tagArticle.ArticleId,
                TagId = tagArticle.TagId
            };
        }

        /// <summary>
        /// Adding tag for article
        /// </summary>
        /// <param name="entity"></param>
        public void Create(DalTagArticle entity)
        {
            var tagArticle= new TagArticle()
            {
                Id = entity.Id,
                ArticleId = entity.ArticleId,
                TagId = entity.TagId
            };
            context.Set<TagArticle>().Add(tagArticle);
            context.SaveChanges();
        }

        /// <summary>
        /// Determination of removing entity
        /// </summary>
        /// <param name="entity">tag of article to delete</param>
        public void Delete(DalTagArticle entity)
        {
            var tagArticle = context.Set<TagArticle>().Where(s => s.Id == entity.Id).FirstOrDefault();
            if (tagArticle != null)
            {
                context.Set<TagArticle>().Remove(tagArticle);
            }
        }

        /// <summary>
        /// Update information about tag of article
        /// </summary>
        /// <param name="entity">tag of article to update</param>
        public void Update(DalTagArticle entity)
        {
            var tagArticle = context.Set<TagArticle>().Where(s => s.Id == entity.Id).FirstOrDefault();
            if (tagArticle != null)
            {
                tagArticle.Id = entity.Id;
                tagArticle.ArticleId = entity.ArticleId;
                tagArticle.TagId = entity.TagId;
            }
        }
    }
}
