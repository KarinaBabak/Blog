using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Blog.DAL.Interface.DTO;

namespace Blog.DAL.Interface.Interface
{
    public interface IRoleRepository: IRepository<DalRole>
    {
        IEnumerable<DalRole> GetByListId(IEnumerable<int> entitiesId);
    }
}
