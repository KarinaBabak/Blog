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
    public class UserRepository : IUserRepository
    {
        private readonly DbContext context;

        public UserRepository(DbContext ctx)
        {
            this.context = ctx;
        }

        #region Realization of IUserRepository
        /// <summary>
        /// Determination of getting all information about user by login
        /// </summary>
        /// <param name="login">login for getting all information about user</param>
        /// <returns>object DalUser</returns>
        public DalUser GetByLogin(string login)
        {
            var user = context.Set<User>().Where(l => l.Login == login).FirstOrDefault();
            if (user != null)
                return new DalUser
                {
                    Id = user.Id,
                    AdditionalInfo = user.AdditionalInfo,
                    Age = user.Age,
                    DateLastVisit = user.DateLastVisit,
                    DateRegistration = user.DateRegistration,
                    Email = user.Email,
                    IsBlocked = user.IsBlocked,
                    Login = user.Login,
                    Name = user.Name,
                    Password = user.Password,
                    Photo = user.Photo,
                    Surname = user.Surname
                };
            return null;
        }

        /// <summary>
        /// Determination of getting all users besides admin
        /// </summary>
        /// <returns>enumeration of users</returns>
        public IEnumerable<DalUser> GetAllBesidesAdmin()
        {
            //var users = context.Set<User>().Where(r=>r.)
            return null;
        }

        /// <summary>
        /// Getting the date of last visit of user
        /// </summary>
        /// <param name="id">id of user</param>
        /// <returns>date of last visit of user</returns>
        public DateTime? GetDateLastVisit(int id)
        {
            var user = context.Set<User>().Where(i => i.Id == id).FirstOrDefault();
            if (user.DateLastVisit != null)
                return user.DateLastVisit;
            return null;
        }
        /// <summary>
        /// Determination of blocking user
        /// </summary>
        /// <param name="userId">id of user to block</param>
        public void BlockUser(int userId)
        {
            var user = context.Set<User>().Where(u => u.Id == userId).FirstOrDefault();
            if (user != null)
            {
                user.IsBlocked = true;
            }
        }

        /// <summary>
        /// Determination of unblocking user
        /// </summary>
        /// <param name="userId">id of user to unblock</param>
        public void UnBlockUser(int userId)
        {
            var user = context.Set<User>().Where(u => u.Id == userId).FirstOrDefault();
            if (user != null)
            {
                user.IsBlocked = false;
            }
        }

        /// <summary>
        /// Getting the enumeration of blocked users
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DalUser> GetBlockedUsers()
        {
            return context.Set<User>().Where(user => user.IsBlocked == true).Select(user => new DalUser()
            {
               Id = user.Id,
               AdditionalInfo = user.AdditionalInfo,
               Age = user.Age,
               DateLastVisit = user.DateLastVisit,
               DateRegistration = user.DateRegistration,
               Email = user.Email,
               IsBlocked = user.IsBlocked,
               Login = user.Login,
               Name = user.Name,
               Password = user.Password,
               Photo = user.Photo,
               Surname = user.Surname
            });
        }
        #endregion

        #region Realization of IRepository
        public IEnumerable<DalUser> GetAll()
        {
            return context.Set<User>().Select(user => new DalUser
            {
                Id = user.Id,
                AdditionalInfo = user.AdditionalInfo,
                Age = user.Age,
                DateLastVisit = user.DateLastVisit,
                DateRegistration = user.DateRegistration,
                Email = user.Email,
                IsBlocked = user.IsBlocked,
                Login = user.Login,
                Name = user.Name,
                Password = user.Password,
                Photo = user.Photo,
                Surname = user.Surname
            });
        }

        /// <summary>
        /// Get the user by id
        /// </summary>
        /// <param name="userId">id of user</param>
        /// <returns>object DalUser</returns>
        public DalUser GetById (int userId)
        {
            //var user = context.Set<User>().FirstOrDefault(u => u.Id == userId);
            return ConvertToDalUser(context.Set<User>().FirstOrDefault(u => u.Id == userId));
        }

        /// <summary>
        /// Adding user to database
        /// </summary>
        /// <param name="dalUser">user to add</param>
        public void Create(DalUser dalUser)
        {
            var user = new User()
            {
                Id = dalUser.Id,
                AdditionalInfo = dalUser.AdditionalInfo,
                Age = dalUser.Age,
                DateLastVisit = dalUser.DateLastVisit,
                DateRegistration = dalUser.DateRegistration,
                Email = dalUser.Email,
                IsBlocked = dalUser.IsBlocked,
                Login = dalUser.Login,
                Name = dalUser.Name,
                Password = dalUser.Password,
                Photo = dalUser.Photo,                
                Surname = dalUser.Surname

            };
            context.Set<User>().Add(user);
            context.SaveChanges();
        }

        /// <summary>
        /// Removing the user
        /// </summary>
        /// <param name="entity">user to remove</param>
        public void Delete(DalUser entity)
        {
            var user = context.Set<User>().FirstOrDefault(u => u.Id == entity.Id);
            var rolesUser = context.Set<RoleUser>().Where(r => r.UserId == user.Id);
            var markers = context.Set<Marker>().Where(m => m.UserId == user.Id);
            if(user!=null)
            {
                context.Set<User>().Remove(user);
            }

            if(rolesUser!=null)
            {
                foreach(var userRole in rolesUser)
                {
                    context.Set<RoleUser>().Remove(userRole);                    
                }
            }
            if(markers != null)
            {
                foreach(var marker in markers)
                {
                    context.Set<Marker>().Remove(marker);
                }
            }
        }

        /// <summary>
        /// Update information about user
        /// </summary>
        /// <param name="entity">user to update it info</param>
        public void Update(DalUser entity)
        {
            var user = context.Set<User>().FirstOrDefault(u => u.Id == entity.Id);
            if(user!=null)
            {
                user.Id = entity.Id;
                user.AdditionalInfo = entity.AdditionalInfo;
                user.Age = entity.Age;
                user.DateLastVisit = entity.DateLastVisit;
                user.DateRegistration = entity.DateRegistration;
                user.Email = entity.Email;
                user.IsBlocked = entity.IsBlocked;
                user.Login = entity.Login;
                user.Name = entity.Name;
                user.Password = entity.Password;
                user.Photo = entity.Photo;
                user.Surname = entity.Surname;
            }
        }
        #endregion

        #region Private Method
        private DalUser ConvertToDalUser(User user)
        {
            if (user != null)
            {
                return new DalUser
                {
                    Id = user.Id,
                    AdditionalInfo = user.AdditionalInfo,
                    Age = user.Age,
                    DateLastVisit = user.DateLastVisit,
                    DateRegistration = user.DateRegistration,
                    Email = user.Email,
                    IsBlocked = user.IsBlocked,
                    Login = user.Login,
                    Name = user.Name,
                    Password = user.Password,
                    Photo = user.Photo,
                    Surname = user.Surname
                };
            }
            return null;
        }
        #endregion


    }
}
