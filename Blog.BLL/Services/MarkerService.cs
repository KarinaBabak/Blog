using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Blog.DAL.Interface.DTO;
using Blog.DAL.Interface.Interface;
using Blog.BLL.Interface.Services;
using Blog.BLL.Interface.Entities;
using Blog.BLL.Services;
using Blog.BLL.Mappers;

namespace Blog.BLL.Services
{
    public class MarkerService: IMarkerService
    {
        private readonly IUnitOfWork uow;
        private readonly IMarkerRepository markerRepository;

        public MarkerService(IUnitOfWork uow, IMarkerRepository repository)
        {
            this.uow = uow;
            this.markerRepository = repository;
        }

        public IEnumerable<ArticleEntity> GetArticleEntityByUserId(int userId)
        {
            return markerRepository.GetByUserId(userId).
                Select(article => article.ToBllArticle());
        }

        public MarkerEntity GetMarkerEntityById(int id)
        {
            return markerRepository.GetById(id).ToBllMarker();
        }
        public IEnumerable<MarkerEntity> GetAllMarkerEntities()
        {
            return markerRepository.GetAll().Select(marker => marker.ToBllMarker());
        }
        public void CreateMarker(MarkerEntity marker)
        {
            markerRepository.Create(marker.ToDalMarker());
            uow.Commit();
        }
        public void DeleteMarker(MarkerEntity marker)
        {
            markerRepository.Delete(marker.ToDalMarker());
            uow.Commit();
        }
        public void UpdateMarker(MarkerEntity marker)
        {
            markerRepository.Update(marker.ToDalMarker());
            uow.Commit();
        }
    }
}
