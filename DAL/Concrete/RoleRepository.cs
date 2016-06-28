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
    public class RoleRepository:IRoleRepository
    {
        private readonly DbContext context;

        public RoleRepository(DbContext dbContext)
        {
            context = dbContext;
        }

        /// <summary>
        /// Getting all roles
        /// </summary>
        /// <returns>an enumeration of all roles</returns>
        public IEnumerable<DalRole> GetAll()
        {
            return context.Set<Role>().Select(role => new DalRole()
            {
                Id = role.Id,
                Name = role.Name
            });
        }

        /// <summary>
        /// Getting role by id
        /// </summary>
        /// <param name="roleId">id of role</param>
        /// <returns>role</returns>
        public DalRole GetById(int roleId)
        {
            var role = context.Set<Role>().Where(r => r.Id == roleId).FirstOrDefault();
            return new DalRole()
            {
                Id = role.Id,
                Name = role.Name
            };
        }

        /// <summary>
        /// Adding role to database
        /// </summary>
        /// <param name="dalUser">role to add</param>
        public void Create(DalRole entity)
        {
            var role = new Role()
            {
                Id = entity.Id,
                Name = entity.Name
            };
            context.Set<Role>().Add(role);
            context.SaveChanges();
        }

        /// <summary>
        /// Removing role
        /// </summary>
        /// <param name="dalRole">role to delete</param>
        public void Delete(DalRole dalRole)
        {
            var role = context.Set<Role>().Where(r => r.Id == dalRole.Id).FirstOrDefault();
            if (role != null)
            {
                context.Set<Role>().Remove(role);
            }  
        }

        /// <summary>
        /// Update information about role
        /// </summary>
        /// <param name="dalRole">role</param>
        public void Update(DalRole dalRole)
        {
            var role = context.Set<Role>().Where(r => r.Id == dalRole.Id).FirstOrDefault();
            if (role != null)
            {
                role.Id = dalRole.Id;
                role.Name = dalRole.Name;
            }
        }

        /// <summary>
        /// Getting roles of user
        /// </summary>
        /// <param name="entitiesId"></param>
        /// <returns></returns>
        public IEnumerable<DalRole> GetByListId(IEnumerable<int> entitiesId)
        {
            return context.Set<Role>().Where(role => entitiesId.Contains(role.Id))
                .Select(role => new DalRole()
                {
                    Id = role.Id,
                    Name = role.Name
                });
        }
    }
}
