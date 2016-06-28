using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.BLL.Interface.Entities;

namespace Blog.BLL.Interface.Services
{
    public interface ISectionService
    {
        SectionEntity GetSectionEntityById(int id);
        IEnumerable<SectionEntity> GetAllSectionEntities();
        void CreateSection(SectionEntity section);
        void DeleteSection(SectionEntity section);
        void UpdateSection(SectionEntity section);
    }
}
