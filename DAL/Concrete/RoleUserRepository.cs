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
    public class RoleUserRepository : IRoleUserRepository
    {
        private readonly DbContext context;

        public RoleUserRepository(DbContext _context)
        {
            this.context = _context;
        }

        /// <summary>
        /// Getting all roles of all users
        /// </summary>
        /// <returns>an enumeration of all roles of all users</returns>
        public IEnumerable<DalRoleUser> GetAll()
        {
            return context.Set<RoleUser>().Select(role => new DalRoleUser()
            {
                Id = role.Id,
                RoleId = role.RoleId,
                UserId = role.UserId
            });
        }

        /// <summary>
        /// Getting role and user
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public DalRoleUser GetById(int entityId)
        {
            var role = context.Set<RoleUser>().Where(r => r.Id == entityId).FirstOrDefault();
            return new DalRoleUser()
            {
                Id = role.Id,
                RoleId = role.RoleId,
                UserId = role.UserId
            };
        }

        /// <summary>
        /// Removing role of user
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(DalRoleUser entity)
        {
            var role = context.Set<RoleUser>().Where(r => r.Id == entity.Id).FirstOrDefault();
            if (role != null)
            {
                context.Set<RoleUser>().Remove(role);
            }
        }

        /// <summary>
        /// Update data about roles of user
        /// </summary>
        /// <param name="entity"></param>
        public void Update(DalRoleUser entity)
        {
            var role = context.Set<RoleUser>().Where(r => r.Id == entity.Id).FirstOrDefault();
            if (role != null)
            {
                role.UserId = entity.UserId;
                role.RoleId = entity.RoleId;
            }
        }

        /// <summary>
        /// Adding new role of user
        /// </summary>
        /// <param name="entity"></param>
        public void Create(DalRoleUser entity)
        {
            var role = new RoleUser()
            {
                Id = entity.Id,
                RoleId = entity.RoleId,
                UserId = entity.UserId
            };
            context.Set<RoleUser>().Add(role);
            context.SaveChanges();
        }

        /// <summary>
        /// Getiing all roles of user
        /// </summary>
        /// <param name="userId">id of user</param>
        /// <returns>an enumeration of all roles of user</returns>
        public IEnumerable<DalRoleUser> GetRolesUserByUserId(int userId)
        {
            return context.Set<RoleUser>().Where(role => role.UserId == userId).Select(role => new DalRoleUser()
            {
                Id = role.Id,
                RoleId = role.RoleId,
                UserId = role.UserId
            });
        }
    }
}
