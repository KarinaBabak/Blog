using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Blog.DAL.Interface.Interface;
using Blog.DAL.Interface.DTO;
using Blog.DAL.Entities;


namespace DAL.Concrete
{
    public class SectionRepository: ISectionRepository
    {
        private readonly DbContext context;
        public SectionRepository(DbContext dbContext)
        {
            context = dbContext;
        }

        /// <summary>
        /// Getting all sections
        /// </summary>
        /// <returns>an enumeration of all sections</returns>
        public IEnumerable<DalSection> GetAll()
        {
            return context.Set<Section>().Select(section => new DalSection()
            {
                Id = section.Id,
                Name = section.Name
            });
        }

        /// <summary>
        /// Get section by id
        /// </summary>
        /// <param name="sectionId">id of section</param>
        /// <returns></returns>
        public DalSection GetById(int sectionId)
        {
            var section = context.Set<Section>().Where(s => s.Id == sectionId).FirstOrDefault();
            return new DalSection()
            {
                Id = section.Id,
                Name = section.Name
            };
        }

        /// <summary>
        /// Adding section
        /// </summary>
        /// <param name="entity">section for adding</param>
        public void Create(DalSection entity)
        {
            var section = new Section()
            {
                Id = entity.Id,
                Name = entity.Name
            };
            context.Set<Section>().Add(section);
            context.SaveChanges();
        }

        /// <summary>
        /// Determination of removing of entity
        /// </summary>
        /// <param name="entity">section to delete</param>
        public void Delete(DalSection entity)
        {
            var section = context.Set<Section>().Where(s => s.Id == entity.Id).FirstOrDefault();
            if (section != null)
            {
                context.Set<Section>().Remove(section);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Update information about section
        /// </summary>
        /// <param name="entity">section to update</param>
        public void Update(DalSection entity)
        {
            var section = context.Set<Section>().Where(s => s.Id == entity.Id).FirstOrDefault();
            if (section != null)
            {
                section.Id = entity.Id;
                section.Name = entity.Name;
            }
        }
    }
}
