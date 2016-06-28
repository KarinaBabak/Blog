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
    public class ArticleService:  IArticleService
    {
        private readonly IUnitOfWork uow;
        private readonly IArticleRepository articleRepository;

        public ArticleService(IUnitOfWork uow, IArticleRepository repository)
        {
            this.uow = uow;
            this.articleRepository = repository;
        }

        public void CreateArticle(ArticleEntity article)
        {
            articleRepository.Create(article.ToDalArticle());
            uow.Commit();
        }
        public void DeleteArticle(ArticleEntity article)
        {
            articleRepository.Delete(article.ToDalArticle());
            uow.Commit();
        }
        public void UpdateArticle(ArticleEntity article)
        {
            articleRepository.Update(article.ToDalArticle());
            uow.Commit();
        }

        public ArticleEntity GetArticleEntityById(int id)
        {
            return articleRepository.GetById(id).ToBllArticle();
        }
        public IEnumerable<ArticleEntity> GetAllArticleEntities()
        {
            return articleRepository.GetAll().Select(article => article.ToBllArticle());
        }

        public IEnumerable<ArticleEntity> GetArticleEntityByTag(int tagId)
        {
            return articleRepository.GetByTag(tagId).Select(article => article.ToBllArticle());
        }
        public IEnumerable<ArticleEntity> GetArticleEntityBySection(int sectionId)
        {
            return articleRepository.GetBySection(sectionId).Select(article => article.ToBllArticle());
        }
        public IEnumerable<ArticleEntity> GetByDatePublication(DateTime datePublication)
        {
            return articleRepository.GetByDatePublication(datePublication).
                Select(article => article.ToBllArticle());
        }
        public IEnumerable<ArticleEntity> GetByBloggerId(int bloggerId)
        {
            return articleRepository.GetByBlogger(bloggerId).Select(article => article.ToBllArticle());
        }

        public IEnumerable<ArticleEntity> Search(string searchString)
        {
            return articleRepository.Search(searchString).Select(article => article.ToBllArticle());
        }
    }
}
