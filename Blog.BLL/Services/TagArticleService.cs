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
    public class TagArticleService: ITagArticleService
    {
        private readonly IUnitOfWork uow;
        private readonly ITagArticleRepository tagArticleRepository;

        public TagArticleService(IUnitOfWork uow, ITagArticleRepository repository)
        {
            this.uow = uow;
            this.tagArticleRepository = repository;
        }

        public TagArticleEntity GetTagArticleEntityById(int id)
        {
            return tagArticleRepository.GetById(id).ToBllTagArticle();
        }
        public IEnumerable<TagArticleEntity> GetAllTagArticleEntities()
        {
            return tagArticleRepository.GetAll().
                Select(tagArticle=>tagArticle.ToBllTagArticle());
        }
        public void CreateTagArticle(TagArticleEntity tagArticle)
        {
            tagArticleRepository.Create(tagArticle.ToDalTagArticle());
            uow.Commit();
        }
        public void DeleteTagArticle(TagArticleEntity tagArticle)
        {
            tagArticleRepository.Delete(tagArticle.ToDalTagArticle());
            uow.Commit();
        }
        public void UpdateTagArticle(TagArticleEntity tagArticle)
        {
            tagArticleRepository.Update(tagArticle.ToDalTagArticle());
            uow.Commit();
        }
    }

}
