using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Blog.BLL.Interface.Entities;

namespace Blog.BLL.Interface.Services
{
    public interface IUserService
    {
        UserEntity GetUserEntityById(int id);
        UserEntity GetUserByLogin(string userName);
        IEnumerable<UserEntity> GetAllUserEntities();
        IEnumerable<UserEntity> GetAllSimpleUsers();
        IEnumerable<UserEntity> GetBlockedUsers(); 
        void BlockUser(int id);
        void UnBlockUser(int id);               
        void CreateUser(UserEntity user);
        void DeleteUser(UserEntity user);
        void UpdateUser(UserEntity user);        
    }
}
