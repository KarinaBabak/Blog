using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Blog.BLL.Interface.Entities;

namespace Blog.BLL.Interface.Services
{
    public interface IRoleUserService
    {
        IEnumerable<RoleUserEntity> GetRolesUserByUserId(int userId);
        IEnumerable<RoleUserEntity> GetAllRoleEntities();        
        RoleUserEntity GetRoleEntityById(int id);        
        void CreateRoleUser(RoleUserEntity roleUser);
        void DeleteRoleUser(RoleUserEntity roleUser);
        void UpdateRoleUser(RoleUserEntity roleUser);
    }
}
