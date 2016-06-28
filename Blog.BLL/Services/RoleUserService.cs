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
    public class RoleUserService : IRoleUserService
    {
        private readonly IUnitOfWork uow;
        private readonly IRoleUserRepository roleRepository;

        public RoleUserService(IUnitOfWork uow, IRoleUserRepository repository)
        {
            this.uow = uow;
            this.roleRepository = repository;
        }


        public RoleUserEntity GetRoleEntityById(int id)
        {
            return roleRepository.GetById(id).ToBllRoleUser();
        }

        public IEnumerable<RoleUserEntity> GetAllRoleEntities()
        {
            return roleRepository.GetAll().Select(roleUser => roleUser.ToBllRoleUser());
        }
        public IEnumerable<RoleUserEntity> GetRolesUserByUserId(int userId)
        {
            return roleRepository.GetRolesUserByUserId(userId).
                Select(roleUser => roleUser.ToBllRoleUser());
        }

        public void CreateRoleUser(RoleUserEntity roleUser)
        {
            roleRepository.Create(roleUser.ToDalRoleUser());
            uow.Commit();
        }

        public void DeleteRoleUser(RoleUserEntity roleUser)
        {
            roleRepository.Delete(roleUser.ToDalRoleUser());
            uow.Commit();
        }

        public void UpdateRoleUser(RoleUserEntity roleUser)
        {
            roleRepository.Update(roleUser.ToDalRoleUser());
            uow.Commit();
        }
    }
}
