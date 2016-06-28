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
    public class RoleService: IRoleService
    {
        private readonly IUnitOfWork uow;
        private readonly IRoleRepository roleRepository;

        public RoleService(IUnitOfWork uow, IRoleRepository repository)
        {
            this.uow = uow;
            this.roleRepository = repository;
        }

        public void CreateRole(RoleEntity role)
        {
            roleRepository.Create(role.ToDalRole());
            uow.Commit();
        }

        public void DeleteRole(RoleEntity role)
        {
            roleRepository.Delete(role.ToDalRole());
            uow.Commit();
        }

        public void UpdateRole(RoleEntity role)
        {
            roleRepository.Update(role.ToDalRole());
            uow.Commit();
        }

        public RoleEntity GetRoleEntityById(int id)
        {
            return roleRepository.GetById(id).ToBllRole();
        }
        public IEnumerable<RoleEntity> GetAllRoleEntities()
        {
            return roleRepository.GetAll().Select(role => role.ToBllRole());
        }

        public IEnumerable<RoleEntity> GetByListId(IEnumerable<int> entitiesId)
        {
            return roleRepository.GetByListId(entitiesId).Select(role => role.ToBllRole()); ;
        }
    }
}
