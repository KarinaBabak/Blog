using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Blog.DAL.Interface.DTO;
using Blog.BLL.Interface.Entities;

namespace Blog.BLL.Mappers
{
    public static class TagArticleEntityMappers
    {
        public static DalTagArticle ToDalTagArticle(this TagArticleEntity tagArticleEntity)
        {
            if (tagArticleEntity != null)
            {
                return new DalTagArticle()
                {
                    Id = tagArticleEntity.Id,
                    ArticleId = tagArticleEntity.ArticleId,
                    TagId = tagArticleEntity.TagId
                };
            }
            return null;
        }

        public static TagArticleEntity ToBllTagArticle(this DalTagArticle dalTagArticle)
        {
            if (dalTagArticle != null)
            {
                return new TagArticleEntity()
                {
                    Id = dalTagArticle.Id,
                    ArticleId = dalTagArticle.ArticleId,
                    TagId = dalTagArticle.TagId
                };
            }
            return null;
        }
    }
}
