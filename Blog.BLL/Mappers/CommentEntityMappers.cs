using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.DAL.Interface.DTO;
using Blog.BLL.Interface.Entities;

namespace Blog.BLL.Mappers
{
    public static class CommentEntityMappers
    {
        /// <summary>
        /// Extension method of type CommentEntity to converte object to DalComment
        /// </summary>
        /// <param name="commentEntity">object CommentEntity to converte to DalComment</param>
        /// <returns>object of DalComment</returns>
        public static DalComment ToDalComment(this CommentEntity commentEntity)
        {
            if (commentEntity != null)
            {
                return new DalComment()
                {
                    Id = commentEntity.Id,
                    ArticleId = commentEntity.ArticleId,
                    Content = commentEntity.Content,
                    DatePublication = commentEntity.DatePublication,
                    SenderId = commentEntity.SenderId,
                    RateUsefulComment = commentEntity.RateUsefulComment
                };
            }
            return null;
        }

        /// <summary>
        /// Extension method of type DalComment
        /// </summary>
        /// <param name="dalComment">object of DalComment</param>
        /// <returns>object of CommentEntity</returns>
        public static CommentEntity ToBllComment(this DalComment dalComment)
        {
            if (dalComment != null)
            {
                return new CommentEntity()
                {
                    Id = dalComment.Id,
                    ArticleId = dalComment.ArticleId,
                    Content = dalComment.Content,
                    DatePublication = dalComment.DatePublication,
                    SenderId = dalComment.SenderId,
                    RateUsefulComment = dalComment.RateUsefulComment
                };
            }
            return null;
        }

    }
}
