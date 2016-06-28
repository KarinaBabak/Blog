using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Blog.DAL.Interface.DTO;

namespace Blog.DAL.Interface.Interface
{
    public interface IRoleUserRepository: IRepository<DalRoleUser>
    {
        IEnumerable<DalRoleUser> GetRolesUserByUserId(int userId);
        //bool IsAdmin(int userId);
    }
}
