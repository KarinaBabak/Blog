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
    public class ArticleRepository : IArticleRepository
    {
        private readonly DbContext context;

        public ArticleRepository(DbContext dbContext)
        {
            context = dbContext;
        }

        /// <summary>
        /// Getting all articles
        /// </summary>
        /// <returns>an enumeration of all articles</returns>
        public IEnumerable<DalArticle> GetAll()
        {
            return context.Set<Article>().Select(a => new DalArticle()
                {                    
                    Id = a.Id,
                    Title = a.Title,
                    Content = a.Content,
                    CountLikes = a.CountLikes,
                    CountShows = a.CountShows,
                    BloggerId = a.BloggerId,
                    DatePublication = a.DatePublication,
                    SectionId = a.SectionId  
                });
        }

        /// <summary>
        /// Getting article by id
        /// </summary>
        /// <param name="entityId">id of article</param>
        /// <returns></returns>
        public DalArticle GetById(int entityId)
        {
            return context.Set<Article>().Where(a => a.Id == entityId).Select(dal => new DalArticle()
                {
                    Id = dal.Id,
                    Title = dal.Title,
                    Content = dal.Content,
                    CountLikes = dal.CountLikes,
                    CountShows = dal.CountShows,
                    BloggerId = dal.BloggerId,
                    DatePublication = dal.DatePublication,
                    SectionId = dal.SectionId  
                }).FirstOrDefault();
        }

        /// <summary>
        /// Adding article to database
        /// </summary>
        /// <param name="entity"></param>
        public void Create(DalArticle entity)
        {
            var article = new Article()
            {
                Id = entity.Id,
                Title = entity.Title,
                Content = entity.Content,
                CountLikes = entity.CountLikes,
                CountShows = entity.CountShows,
                BloggerId = entity.BloggerId,
                DatePublication = entity.DatePublication,
                SectionId = entity.SectionId
            };

            context.Set<Article>().Add(article);
            context.SaveChanges();
        }

        /// <summary>
        /// Removing article
        /// </summary>
        /// <param name="entity">article for removing</param>
        public void Delete(DalArticle entity)
        {
            var article = context.Set<Article>().Where(a => a.Id == entity.Id).FirstOrDefault();
            if (article != null)
                context.Set<Article>().Remove(article);
            var tagArticle = context.Set<TagArticle>().Where(ta => ta.ArticleId == article.Id);
            if (tagArticle != null)
            {
                foreach (var entry in tagArticle)
                {
                    context.Set<TagArticle>().Remove(entry);                    
                }                
            }
            var comments = context.Set<Comment>().Where(a => a.ArticleId == entity.Id);
            if(comments!= null)
            {
                foreach(var comment in comments)
                {
                    context.Set<Comment>().Remove(comment);
                }
            }

            context.SaveChanges();
            
        }
   
        /// <summary>
        /// Update information about article
        /// </summary>
        /// <param name="entity">article to update</param>
        public void Update(DalArticle entity)
        {
            var article = context.Set<Article>().Where(a => a.Id == entity.Id).FirstOrDefault();
            if(article != null)
            {
                article.Id = entity.Id;
                article.Title = entity.Title;
                article.Content = entity.Content;
                article.CountLikes = entity.CountLikes;
                article.CountShows = entity.CountShows;
                article.BloggerId = entity.BloggerId;
                article.DatePublication = entity.DatePublication;
                article.SectionId = entity.SectionId;
                context.SaveChanges();
            }
        }

        #region Realization of IArticleRepozitory

        /// <summary>
        /// Searching content article by string  
        /// </summary>
        /// <param name="searchString">string for searching</param>
        /// <returns></returns>
        public IEnumerable<DalArticle> Search(string searchString)
        {
            //var articles = context.Set<Article>().Where(s => s.Content.Contains(searchString));
            var result = from article in context.Set<Article>()
                         where (article.Content.Contains(searchString)
                         || article.Title.Contains(searchString))
                         select article;
            return ConvertToDalArticle(result);
        }

        /// <summary>
        /// Getting articles by tag
        /// </summary>
        /// <param name="tagId"></param>
        /// <returns></returns>
        public IEnumerable<DalArticle> GetByTag(int tagId)
        {
            var articles = from tag in context.Set<Tag>()
                           join ti in context.Set<TagArticle>()
                           on tag.Id equals ti.TagId
                           where tag.Id == tagId
                           select ti.Article;
            if (articles != null)
                return ConvertToDalArticle(articles);
            return null;            
        }

        /// <summary>
        /// Getting all articles of section
        /// </summary>
        /// <param name="sectionId">id of section</param>
        /// <returns>articles of section</returns>
        public IEnumerable<DalArticle> GetBySection(int sectionId)
        {
            return ConvertToDalArticle(context.Set<Article>().Where(s => s.SectionId == sectionId));
        }

        /// <summary>
        /// Getting all articles by date of publication
        /// </summary>
        /// <param name="datePublication">date of publication article</param>
        /// <returns>all articles by date of publication</returns>
        public IEnumerable<DalArticle> GetByDatePublication(DateTime datePublication)
        {
            return ConvertToDalArticle(context.Set<Article>().Where(d=>d.DatePublication == datePublication));
        }

        /// <summary>
        /// Getting all articles of blogger by id
        /// </summary>
        /// <param name="bloggerId">id of blogger</param>
        /// <returns>all articles of blogger</returns>
        public IEnumerable<DalArticle> GetByBlogger(int bloggerId)
        {
            return ConvertToDalArticle(context.Set<Article>().Where(b=>b.BloggerId == bloggerId));
        }
        #endregion

        /// <summary>
        /// Converting enumeration of Article to enumeration of DalArticle
        /// </summary>
        /// <param name="articles"></param>
        /// <returns></returns>
        private IEnumerable<DalArticle> ConvertToDalArticle(IEnumerable<Article> articles)
        {
            if (articles == null) return null;
            List<DalArticle> listDalArticle = new List<DalArticle>();
            foreach(var article in articles)
            {
                listDalArticle.Add(new DalArticle()
                    {
                        Id = article.Id,
                        Title = article.Title,
                        Content = article.Content,
                        CountLikes = article.CountLikes,
                        CountShows = article.CountShows,
                        BloggerId = article.BloggerId,
                        DatePublication = article.DatePublication,
                        SectionId = article.SectionId                        
                    });
            }
            return listDalArticle;
        }
    }
}
