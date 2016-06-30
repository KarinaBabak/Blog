using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Blog.DAL.Interface.DTO;
using Blog.BLL.Interface.Entities;

namespace Blog.BLL.Mappers
{
    public static class UserEntityMappers
    {
        public static DalUser ToDalUser(this UserEntity userEntity)
        {
            if (userEntity != null)
            {
                return new DalUser()
                {
                    Id = userEntity.Id,
                    AdditionalInfo = userEntity.AdditionalInfo,
                    Age = userEntity.Age,               
                    Email = userEntity.Email,
                    IsBlocked = userEntity.IsBlocked,
                    Login = userEntity.Login,
                    Name = userEntity.Name,
                    Password = userEntity.Password,
                    Photo = userEntity.Photo,
                    Surname = userEntity.Surname
                };
            }
            return null;
        }

        public static UserEntity ToBllUser(this DalUser dalUser)
        {
            if (dalUser != null)
            {
                return new UserEntity()
                {
                    Id = dalUser.Id,
                    AdditionalInfo = dalUser.AdditionalInfo,
                    Age = dalUser.Age,                   
                    DateRegistration = dalUser.DateRegistration,
                    Email = dalUser.Email,
                    IsBlocked = dalUser.IsBlocked,
                    Login = dalUser.Login,
                    Name = dalUser.Name,
                    Password = dalUser.Password,
                    Photo = dalUser.Photo,
                    Surname = dalUser.Surname
                };
            }
            return null;
        }
    }
}
