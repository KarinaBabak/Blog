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
    public class TagService : ITagService
    {
        private readonly IUnitOfWork uow;
        private readonly ITagRepository tagRepository;

        public TagService(IUnitOfWork uow, ITagRepository repository)
        {
            this.uow = uow;
            this.tagRepository = repository;
        }

        public void CreateTag(TagEntity tag)
        {
            tagRepository.Create(tag.ToDalTag());
            uow.Commit();
        }
        public void DeleteTag(TagEntity tag)
        {
            tagRepository.Delete(tag.ToDalTag());
            uow.Commit();
        }
        public void UpdateTag(TagEntity tag)
        {
            tagRepository.Update(tag.ToDalTag());
            uow.Commit();
        }
        public TagEntity GetTagEntityById(int id)
        {
            return tagRepository.GetById(id).ToBllTag();
        }
        public IEnumerable<TagEntity> GetAllTagEntities()
        {
            return tagRepository.GetAll().Select(tag => tag.ToBllTag());
        }

        public IEnumerable<TagEntity> GetTagsOfArticle(int articleId)
        {
            return tagRepository.GetTagsOfArticle(articleId).Select(tag => tag.ToBllTag());
        }
        
    }
}
