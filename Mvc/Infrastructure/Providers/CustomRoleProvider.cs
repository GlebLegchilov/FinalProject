using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using BLLInterface;
using BLLInterface.Entities;
using BLLInterface.Services;

namespace Mvc.Infrastructure.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        public override string ApplicationName { get; set; }

        private IUserService userService => (IUserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserService));
        private IRoleService roleService => (IRoleService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IRoleService));


        public override bool IsUserInRole(string name, string roleName)
        {

            UserEntity user = userService.GetAllUsers().FirstOrDefault(u => u.UserName == name);

            if (user == null) return false;

            RoleEntity userRole = roleService.GetRole(user.RoleId);

            if (userRole != null && userRole.Name == roleName)
            {
                return true;
            }

            return false;
        }

        public override string[] GetRolesForUser(string name)
        {
            var roles = new string[] { };
            var user = userService.GetUser(name);

            if (user == null) return roles;

            var userRole = roleService.GetRole(user.RoleId);

            if (userRole != null)
            {
                roles = new string[] { userRole.Name };
            }
            return roles;
        }

        #region Stubs
        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }
        #endregion
        
    }
}