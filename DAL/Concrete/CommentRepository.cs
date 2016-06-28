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
    public class CommentRepository: ICommentRepository
    {
        private readonly DbContext context;

        public CommentRepository(DbContext dbContext)
        {
            this.context = dbContext;
        }

        /// <summary>
        /// Getting all comments
        /// </summary>
        /// <returns>an enumeration of all comments</returns>
        public IEnumerable<DalComment> GetAll()
        {
            return context.Set<Comment>().Select(comment => new DalComment()
            {
                Id = comment.Id,
                ArticleId = comment.ArticleId,                
                SenderId = comment.SenderId,
                Content = comment.Content,
                DatePublication = comment.DatePublication,
                RateUsefulComment = comment.RateUsefulComment   
            });
        }

        /// <summary>
        /// Get the comment by id
        /// </summary>
        /// <param name="entityId">id of comment</param>
        /// <returns>object DalComment</returns>
        public DalComment GetById(int entityId)
        {
            return ConvertToDalComment(context.Set<Comment>().FirstOrDefault(u => u.Id == entityId));
        }

        /// <summary>
        /// Add the entry to database
        /// </summary>
        /// <param name="entity"></param>
        public void Create(DalComment entity)
        {
            var comment = new Comment()
            {
                Id = entity.Id,
                ArticleId = entity.ArticleId,
                Content = entity.Content,
                DatePublication = entity.DatePublication,
                SenderId = entity.SenderId,
                RateUsefulComment = entity.RateUsefulComment
            };
            context.Set<Comment>().Add(comment);
            context.SaveChanges();
        }

        /// <summary>
        /// Removing the comment
        /// </summary>
        /// <param name="entity">comment to delete</param>
        public void Delete(DalComment entity)
        {
            var comment = context.Set<Comment>().Where(c => c.Id == entity.Id).FirstOrDefault();
            if (comment != null)
            {
                context.Set<Comment>().Remove(comment);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Update information about comment
        /// </summary>
        /// <param name="entity">comment to update</param>
        public void Update(DalComment entity)
        {
            var comment = context.Set<Comment>().Where(c => c.Id == entity.Id).FirstOrDefault();
            if(comment != null)
            {
                comment.Id = entity.Id;
                comment.ArticleId = entity.ArticleId;
                comment.Content = entity.Content;
                comment.DatePublication = entity.DatePublication;
                comment.SenderId = entity.SenderId;
                comment.RateUsefulComment = entity.RateUsefulComment;
            }            
        }

        #region Realization of ICommentRepository
        /// <summary>
        /// Getting the enumeration of comments of article by id of article
        /// </summary>
        /// <param name="articleId">id of article</param>
        /// <returns>an enumeration of comments of article</returns>
        public IEnumerable<DalComment> GetByArticle(int articleId)
        {
            return context.Set<Comment>().Where(a => a.ArticleId == articleId).
                Select(comment => new DalComment
                {
                    Id = comment.Id,
                    ArticleId = comment.ArticleId,
                    SenderId = comment.SenderId,
                    Content = comment.Content,
                    DatePublication = comment.DatePublication,
                    RateUsefulComment = comment.RateUsefulComment
                });           
        }
        #endregion

        #region Private Method
        private DalComment ConvertToDalComment(Comment comment)
        {
            if (comment != null)
                return new DalComment()
                {
                    Id = comment.Id,
                    ArticleId = comment.ArticleId,
                    SenderId = comment.SenderId,
                    Content = comment.Content,
                    DatePublication = comment.DatePublication,
                    RateUsefulComment = comment.RateUsefulComment
                };
            return null;
        }
        #endregion
    }
}
