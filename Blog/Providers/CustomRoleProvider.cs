using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using Blog.BLL.Interface.Services;
using Blog.BLL.Interface.Entities;

namespace Blog.Providers
{
    public class CustomRoleProvider: RoleProvider
    {
        public IUserService UserService
        {
            get { return (IUserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserService)); }
        }

        public IRoleService RoleService
        {
            get { return (IRoleService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IRoleService)); }
        }

        public IRoleUserService RoleUserService
        {
            get { return (IRoleUserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IRoleUserService)); }
        }

        /// <summary>
        /// Determination of checking there is a user role
        /// </summary>
        /// <param name="login">user login</param>
        /// <param name="roleName">name of role</param>
        /// <returns>true if user has a role</returns>
        public override bool IsUserInRole(string login, string roleName)
        {
            UserEntity user = UserService.GetUserByLogin(login);
            if (user == null)
            {
                return false;
            }
            
            var userRolesId = RoleUserService.GetRolesUserByUserId(user.Id).Select(role=>role.RoleId);
            IEnumerable<RoleEntity> userRoles = RoleService.GetByListId(userRolesId);

            if (userRoles == null)
            {
                return false;
            }
            foreach (var userRole in userRoles)
            {
                if (userRole.Name == roleName)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Getting all roles of user by login
        /// </summary>
        /// <param name="login">login of user</param>
        /// <returns>array of user roles</returns>
        public override string[] GetRolesForUser(string login)
        {            
            List<string> roles = new List<string>();
            var user = UserService.GetUserByLogin(login);
            if (user == null)
            {
                return roles.ToArray();
            }
            var userRolesId = RoleUserService.GetRolesUserByUserId(user.Id).Select(i => i.RoleId);
            var userRoles = RoleService.GetByListId(userRolesId);
                          
            if(userRoles != null)
            {
                foreach(var role in userRoles)
                {
                    roles.Add(role.Name);
                }
            }

            return roles.ToArray();
        }

        /// <summary>
        /// Adding new role
        /// </summary>
        /// <param name="roleName">name of new role</param>
        public override void CreateRole(string roleName)
        {
            var newRole = new RoleEntity() { Name = roleName };
            RoleService.CreateRole(newRole);
        }

        #region Stab
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }



        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }


        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }


        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}