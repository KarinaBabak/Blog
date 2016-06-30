using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Blog.Models;
using Blog.BLL.Interface.Services;
using Blog.BLL.Interface.Entities;
using Blog.Providers;
using Blog.Mappers;
using Blog.BLL.Services;

namespace Blog.Models
{
    public static class TagHelper
    {        
        public static ITagService TagService
        {
            get { return (ITagService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(ITagService)); }
        }

        public static ITagArticleService TagArticleService
        {
            get { return (ITagArticleService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(ITagArticleService)); }
        }              
             
        public static void CreateArticle(string tagsOfArticle, int articleId)
        {           
            if (tagsOfArticle == null) return;
            string[] tags = tagsOfArticle.Split(',');
            var results = TagService.GetAllTagEntities();
            foreach (string entry in tags)
            {
                string tag = entry.Trim();
                var tagFromResult = results.FirstOrDefault(t => t.Name == tag);
                
                if (tagFromResult == null)
                {
                    TagService.CreateTag(new TagEntity()
                        {
                            Name = tag
                        });           
                }

                var tagFromDb = TagService.GetAllTagEntities().FirstOrDefault(t => t.Name == tag); 

                TagArticleService.CreateTagArticle(new TagArticleEntity()
                {
                    ArticleId = articleId,
                    TagId = tagFromDb.Id
                });
            
            }            
        }
               

        /// <summary>
        /// Getting all tags of article
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public static IEnumerable<String> GetTagsOfArticle(int articleId)
        {
            var tags = TagService.GetTagsOfArticle(articleId);
            if (tags != null) return tags.Select(t=>t.Name);
            return null;
        }

        public static void DeleteTagArticle(int articleId)
        {
            TagArticleService.DeleteByArticleId(articleId);
        }
        
    }
}