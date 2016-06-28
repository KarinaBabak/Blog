using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Blog.BLL.Interface.Entities;

namespace Blog.BLL.Interface.Services
{
    public interface IArticleService
    {
        IEnumerable<ArticleEntity> GetArticleEntityByTag(int tagId);
        IEnumerable<ArticleEntity> GetArticleEntityBySection(int sectionId);
        IEnumerable<ArticleEntity> GetByDatePublication(DateTime datePublication);
        IEnumerable<ArticleEntity> GetByBloggerId(int bloggerId);
        IEnumerable<ArticleEntity> Search(string searchString);

        ArticleEntity GetArticleEntityById(int id);
        IEnumerable<ArticleEntity> GetAllArticleEntities();
        void CreateArticle(ArticleEntity article);
        void DeleteArticle(ArticleEntity article);
        void UpdateArticle(ArticleEntity article);
    }
}
