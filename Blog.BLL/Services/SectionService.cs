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
    public class SectionService : ISectionService
    {
        private readonly IUnitOfWork uow;
        private readonly ISectionRepository sectionRepository;

        public SectionService(IUnitOfWork uow, ISectionRepository repository)
        {
            this.uow = uow;
            this.sectionRepository = repository;
        }

        public void CreateSection(SectionEntity section)
        {
            sectionRepository.Create(section.ToDalSection());
            uow.Commit();
        }
        public void DeleteSection(SectionEntity section)
        {
            sectionRepository.Delete(section.ToDalSection());
            uow.Commit();
        }
        public void UpdateSection(SectionEntity section)
        {
            sectionRepository.Update(section.ToDalSection());
            uow.Commit();
        }
        public SectionEntity GetSectionEntityById(int id)
        {
            return sectionRepository.GetById(id).ToBllSection();
        }
        public IEnumerable<SectionEntity> GetAllSectionEntities()
        {
            return sectionRepository.GetAll().Select(section => section.ToBllSection());
        }
        
    }
}
