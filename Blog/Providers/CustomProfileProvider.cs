using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Profile;
using System.Configuration;
using Blog.BLL.Interface.Services;
using Blog.BLL.Interface.Entities;


namespace Blog.Providers
{
    public class CustomProfileProvider: ProfileProvider
    {
        public IUserService UserService
        {
            get { return (IUserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserService)); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="collection">collection profile properties</param>
        /// <returns>collection of property values</returns>
        public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context, SettingsPropertyCollection collection)
        {
            var result = new SettingsPropertyValueCollection();

            if (collection == null || collection.Count < 1 || context == null)
            {
                return result;
            }

            var userName = (string)context["UserName"];
            if (String.IsNullOrEmpty(userName))
            {
                return result;
            }

            UserEntity user = UserService.GetUserByLogin(userName);
            if (userName != null)
            {
                foreach (SettingsProperty property in collection)
                {
                    var spv = new SettingsPropertyValue(property)
                    {
                        PropertyValue = user.GetType().GetProperty(property.Name).GetValue(user, null)
                    };
                    result.Add(spv);
                }
            }
            else
            {
                foreach (SettingsProperty property in collection)
                {
                    var svp = new SettingsPropertyValue(property) { PropertyValue = null };
                    result.Add(svp);
                }
            }
            return result;
        }

        public override void SetPropertyValues(SettingsContext context, SettingsPropertyValueCollection collection)
        {
            var userName = (string)context["Login"];

            if (string.IsNullOrEmpty(userName) || collection.Count < 1)
            {
                return;
            }
            UserEntity user = UserService.GetUserByLogin(userName);
            if (userName != null)
            {
                foreach (SettingsPropertyValue value in collection)
                {
                    user.GetType().GetProperty(value.Property.Name).SetValue(user, value.PropertyValue);
                }
                user.DateLastVisit = DateTime.Now;
            }
        }
        public override string ApplicationName { get; set; }
        #region Stab
        public override int DeleteInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate)
        {
            throw new NotImplementedException();
        }

        public override int DeleteProfiles(string[] usernames)
        {
            throw new NotImplementedException();
        }

        public override int DeleteProfiles(ProfileInfoCollection profiles)
        {
            throw new NotImplementedException();
        }

        public override ProfileInfoCollection FindInactiveProfilesByUserName(ProfileAuthenticationOption authenticationOption, string usernameToMatch, DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override ProfileInfoCollection FindProfilesByUserName(ProfileAuthenticationOption authenticationOption, string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override ProfileInfoCollection GetAllInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override ProfileInfoCollection GetAllProfiles(ProfileAuthenticationOption authenticationOption, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate)
        {
            throw new NotImplementedException();
        }
        
        #endregion
    }
}