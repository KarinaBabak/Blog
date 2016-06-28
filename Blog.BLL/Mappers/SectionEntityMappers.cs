using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Blog.DAL.Interface.DTO;
using Blog.BLL.Interface.Entities;

namespace Blog.BLL.Mappers
{
    public static class SectionEntityMappers
    {
        public static DalSection ToDalSection(this SectionEntity sectionEntity)
        {
            if (sectionEntity != null)
            {
                return new DalSection()
                {
                    Id = sectionEntity.Id,
                    Name = sectionEntity.Name                    
                };
            }
            return null;
        }

        public static SectionEntity ToBllSection(this DalSection dalSection)
        {
            if (dalSection != null)
            {
                return new SectionEntity()
                {
                    Id = dalSection.Id,
                    Name = dalSection.Name                    
                };
            }
            return null;
        }
    }
}
