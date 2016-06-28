using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Blog.BLL.Interface.Entities;

namespace Blog.BLL.Interface.Services
{
    public interface IMarkerService
    {
        IEnumerable<ArticleEntity> GetArticleEntityByUserId(int userId);

        MarkerEntity GetMarkerEntityById(int id);
        IEnumerable<MarkerEntity> GetAllMarkerEntities();
        void CreateMarker(MarkerEntity marker);
        void DeleteMarker(MarkerEntity marker);
        void UpdateMarker(MarkerEntity marker);
    }
}
