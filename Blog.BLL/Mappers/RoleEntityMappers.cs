using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Blog.DAL.Interface.DTO;
using Blog.BLL.Interface.Entities;

namespace Blog.BLL.Mappers
{
    public static class RoleEntityMappers
    {
        public static DalRole ToDalRole(this RoleEntity roleEntity)
        {
            if (roleEntity != null)
            {
                return new DalRole()
                {
                    Id = roleEntity.Id,
                    Name = roleEntity.Name
                };
            }
            return null;
        }

        public static RoleEntity ToBllRole(this DalRole dalRole)
        {
            if (dalRole != null)
            {
                return new RoleEntity()
                {
                    Id = dalRole.Id,
                    Name = dalRole.Name
                };
            }
            return null;
        }
    }
}
