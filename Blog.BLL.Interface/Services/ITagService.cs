using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Blog.BLL.Interface.Entities;

namespace Blog.BLL.Interface.Services
{
    public interface ITagService
    {
        TagEntity GetTagEntityById(int id);
        IEnumerable<TagEntity> GetAllTagEntities();        
        IEnumerable<TagEntity> GetTagsOfArticle(int articleId);
        void CreateTag(TagEntity tag);
        void DeleteTag(TagEntity tag);
        void UpdateTag(TagEntity tag);
    }
}
