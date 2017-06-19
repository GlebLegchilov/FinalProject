using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using BLLInterface;
using BLLInterface.Entities;
using BLLInterface.Services;

namespace MvcPL.Infrastructure.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        //public IUserRepository UserRepository
        //    => (IUserRepository)DependencyResolver.Current.GetService(typeof(IUserRepository));

        //public IRoleRepository RoleRepository
        //    => (IRoleRepository)DependencyResolver.Current.GetService(typeof(IRoleRepository));

        private readonly IUserService userService;
        private readonly IRoleService roleService;

        public override bool IsUserInRole(string name, string roleName)
        {

            UserEntity user = userService.GetAllUserEntities().FirstOrDefault(u => u.UserName == name);

            if (user == null) return false;

            RoleEntity userRole = roleService.GetById(user.RoleId);

            if (userRole != null && userRole.Name == roleName)
            {
                return true;
            }

            return false;
        }

        public override string[] GetRolesForUser(string name)
        {
            var roles = new string[] { };
            var user = userService.GetUserEntityByName(name);

            if (user == null) return roles;
            
            var userRole = roleService.GetById(user.RoleId);

            if (userRole != null)
            {
                roles = new string[] { userRole.Name };
            }
            return roles;      
        }

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

        public override string ApplicationName { get; set; }
    }
}