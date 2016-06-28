using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.DAL.Interface.DTO;
using Blog.BLL.Interface.Entities;

namespace Blog.BLL.Mappers
{
    public static class MarkerEntityMappers
    {
        public static DalMarker ToDalMarker(this MarkerEntity markerEntity)
        {
            if (markerEntity != null)
            {
                return new DalMarker()
                {
                    Id = markerEntity.Id,
                    UserId = markerEntity.UserId,
                    ArticleId = markerEntity.ArticleId
                };
            }
            return null;
        }

        public static MarkerEntity ToBllMarker(this DalMarker dalMarker)
        {
            if (dalMarker != null)
            {
                return new MarkerEntity()
                {
                    Id = dalMarker.Id,
                    UserId = dalMarker.UserId,
                    ArticleId = dalMarker.ArticleId
                };
            }
            return null;
        }
    }
}
