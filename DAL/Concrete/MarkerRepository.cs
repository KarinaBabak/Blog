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
    public class MarkerRepository : IMarkerRepository
    {
        private readonly DbContext context;
        public MarkerRepository(DbContext dbContext)
        {
            this.context = dbContext;
        }

        /// <summary>
        /// Getting all articles that users like
        /// </summary>
        /// <returns>an enumeration of all markers</returns>
        public IEnumerable<DalMarker> GetAll()
        {
            return context.Set<Marker>().Select(marker => new DalMarker()
            {
                Id = marker.Id,
                UserId = marker.UserId,
                ArticleId = marker.ArticleId
            });
        }

        /// <summary>
        /// Get the marker by id
        /// </summary>
        /// <param name="entityId">id of marker</param>
        /// <returns>object DalMarker</returns>
        public DalMarker GetById(int entityId)
        {
            return context.Set<Marker>().Where(m => m.Id == entityId).Select(marker => new DalMarker()
            {
                Id = marker.Id,
                UserId = marker.UserId,
                ArticleId = marker.ArticleId
            }).FirstOrDefault();
        }

        /// <summary>
        /// Add the entry to database
        /// </summary>
        /// <param name="entity"></param>
        public void Create(DalMarker entity)
        {
            var marker = new Marker()
            {
                Id = entity.Id,
                UserId = entity.UserId,
                ArticleId = entity.ArticleId
            };
            context.Set<Marker>().Add(marker);
            context.SaveChanges();
        }

        /// <summary>
        /// Removing the marler
        /// </summary>
        /// <param name="entity">marker to delete</param>
        public void Delete(DalMarker entity)
        {
            var marker = context.Set<Marker>().Where(c => c.Id == entity.Id).FirstOrDefault();
            if (marker != null)
                context.Set<Marker>().Remove(marker);
        }

        /// <summary>
        /// Update information about marker
        /// </summary>
        /// <param name="entity">marker to update</param>
        public void Update(DalMarker entity)
        {
            var marker = context.Set<Marker>().Where(c => c.Id == entity.Id).FirstOrDefault();
            if (marker != null)
            {
                marker.Id = entity.Id;
                marker.UserId = entity.UserId;
                marker.ArticleId = entity.ArticleId;
            }
        }

        /// <summary>
        /// Getting all markers of user
        /// </summary>
        /// <param name="userId">id of user</param>
        /// <returns>an enumeration of user's markers</returns>
        public IEnumerable<DalArticle> GetByUserId(int userId)
        {
            return (from marker in context.Set<Marker>()
                    join article in context.Set<Article>()
                    on marker.ArticleId equals article.Id
                    where marker.UserId == userId
                    select article).Select(article => new DalArticle()
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
    }
}
