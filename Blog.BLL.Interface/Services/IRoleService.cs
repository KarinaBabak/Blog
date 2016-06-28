using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Blog.BLL.Interface.Entities;

namespace Blog.BLL.Interface.Services
{
    public interface IRoleService
    {
        RoleEntity GetRoleEntityById(int id);
        IEnumerable<RoleEntity> GetAllRoleEntities();
        IEnumerable<RoleEntity> GetByListId(IEnumerable<int> entitiesId);
        void CreateRole(RoleEntity user);
        void DeleteRole(RoleEntity user);
        void UpdateRole(RoleEntity user);
    }
}
