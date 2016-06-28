using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Blog.DAL.Interface.DTO;
using Blog.BLL.Interface.Entities;

namespace Blog.BLL.Mappers
{
    public static class ArticleEntityMappers
    {
        public static DalArticle ToDalArticle(this ArticleEntity articleEntity)
        {
            if(articleEntity != null)
            {
                return new DalArticle()
                {
                    Id = articleEntity.Id,
                    Title = articleEntity.Title,
                    Content = articleEntity.Content,
                    CountLikes = articleEntity.CountLikes,
                    CountShows = articleEntity.CountShows,
                    BloggerId = articleEntity.BloggerId,
                    DatePublication = articleEntity.DatePublication,
                    SectionId = articleEntity.SectionId
                };
            }
            return null;
        }

        public static ArticleEntity ToBllArticle(this DalArticle dalArticle)
        {
            if (dalArticle != null)
            {
                return new ArticleEntity()
                {
                    Id = dalArticle.Id,
                    Title = dalArticle.Title,
                    Content = dalArticle.Content,
                    CountLikes = dalArticle.CountLikes,
                    CountShows = dalArticle.CountShows,
                    BloggerId = dalArticle.BloggerId,
                    DatePublication = dalArticle.DatePublication,
                    SectionId = dalArticle.SectionId
                };
            }
            return null;
        }
    }
}
