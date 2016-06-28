using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Blog.BLL.Interface.Entities;

namespace Blog.BLL.Interface.Services
{
    public interface ITagArticleService
    {
        TagArticleEntity GetTagArticleEntityById(int id);
        IEnumerable<TagArticleEntity> GetAllTagArticleEntities();
        void CreateTagArticle(TagArticleEntity tagArticle);
        void DeleteTagArticle(TagArticleEntity tagArticle);
        void UpdateTagArticle(TagArticleEntity tagArticle);
    }
}
