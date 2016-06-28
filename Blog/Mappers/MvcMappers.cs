using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Blog.Models;
using Blog.ViewModels;
using Blog.BLL.Interface.Entities;

namespace Blog.Mappers
{
    public static class MvcMappers
    {
        public static UserEntity ToBllUser(this RegisterViewModel model)
        {
            if (model != null)
            {
                return new UserEntity()
                {
                    Id = model.Id,
                    Login = model.Login,
                    Password = model.Password,
                    Name = model.Name,
                    Surname = model.Surname,
                    Email = model.Email,
                    DateRegistration = model.DateRegistration
                };
            }
            return null;
        }

        public static RegisterViewModel ToModelRegister(this UserEntity entity)
        {
            if(entity != null)
            {
                return new RegisterViewModel()
                {
                    Id = entity.Id,
                    Login = entity.Login,
                    Password = entity.Password,
                    Name = entity.Name,
                    Surname = entity.Surname,
                    Email = entity.Email,
                    DateRegistration = entity.DateRegistration
                };
            }
            return null;
        }

        public static LogOnViewModel ToLogInModelUser (this UserEntity entity)
        {
            if(entity!= null)
            {
                return new LogOnViewModel()
                {
                    Login = entity.Login,
                    Password = entity.Password
                };
            }
            return null;
        }
                

       public static ArticleEntity ToBllArticle(this ArticleViewModel model)
        {
           if(model != null)
           {
               return new ArticleEntity()
               {
                   Id=model.Id,
                   Title = model.Title,
                   Content = model.Content,
                   CountShows = model.CountShows,
                   CountLikes = model.CountLikes,
                   DatePublication = model.DatePublication,
                   BloggerId = model.BloggerId,                   
                   SectionId = model.SectionId                   
               };
           }
           return null;
        }

       public static ArticleEntity ToBllArticle(this ArticleModel model)
       {
           if (model != null)
           {
               return new ArticleEntity()
               {
                   Id = model.Id,
                   Title = model.Title,
                   Content = model.Content,
                   CountShows = model.CountShows,
                   CountLikes = model.CountLikes,
                   DatePublication = model.DatePublication,
                   BloggerId = model.BloggerId,
                   SectionId = model.SectionId
               };
           }
           return null;
       }

        public static ArticleViewModel ToViewModelArticle (this ArticleEntity entity)
        {
            if( entity != null)
            {
                return new ArticleViewModel()
                {
                    Id = entity.Id,
                    DatePublication = entity.DatePublication,
                    BloggerId = entity.BloggerId,
                    Content = entity.Content,
                    CountLikes = entity.CountLikes,
                    CountShows = entity.CountShows,
                    SectionId = entity.SectionId,
                    Title = entity.Title
                };
            }
            return null;
        }

        public static ArticleModel ToModelArticle(this ArticleEntity article, UserModel sender=null)
        {
            return new ArticleModel()
            {
                Id = article.Id,
                DatePublication = article.DatePublication,
                BloggerId = article.BloggerId,
                Content = article.Content,
                CountLikes = article.CountLikes,
                CountShows = article.CountShows,
                SectionId = article.SectionId,
                Title = article.Title,
                Blogger = sender
            };
        }

        public static UserModel ToModelUser(this UserEntity entity)
        {
            return new UserModel()
            {
                Id = entity.Id,
                AdditionalInfo = entity.AdditionalInfo,
                Age = entity.Age,
                DateLastVisit = entity.DateLastVisit,
                DateRegistration = entity.DateRegistration,
                Email = entity.Email,
                IsBlocked = entity.IsBlocked,
                Login = entity.Login,
                Name = entity.Name,
                Password = entity.Password,
                Photo = entity.Photo,
                Surname = entity.Surname
            };
        }

        public static SectionViewModel ToModelSection(this SectionEntity entity)
       {
            if(entity != null)
            {
                return new SectionViewModel()
                {
                    Id = entity.Id,
                    Name = entity.Name
                };
            }
            return null;
       }

        public static TagViewModel ToModelTag(this TagEntity model)
        {
            if(model!= null)
            {
                return new TagViewModel()
                {
                    Id = model.Id,
                    Name = model.Name
                };
            }
            return null;
        }

        public static CommentEntity ToBllComment(this CommentViewModel model)
        {
            if(model!=null)
            {
                return new CommentEntity()
                {
                    Id = model.Id,
                    ArticleId = model.ArticleId,
                    Content = model.Content,
                    DatePublication = model.DatePublication,
                    SenderId = model.SenderId
                };
            }
            return null;
        }

        public static CommentModel ToModelComment (this CommentEntity entity)
        {
            if(entity!=null)
            {
                return new CommentModel()
                {
                    ArticleId = entity.ArticleId,
                    Content = entity.Content,
                    DatePublication = entity.DatePublication,
                    Id = entity.Id,
                    SenderId = entity.SenderId
                };
            }
            return null;
        }
       
    }
}