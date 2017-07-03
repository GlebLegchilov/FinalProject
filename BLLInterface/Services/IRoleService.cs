using System.Collections.Generic;
using BLLInterface.Entities;

namespace BLLInterface.Services
{
    public interface IRoleService 
    {
        RoleEntity GetRole(int id);
        RoleEntity GetRoleUser();
        IEnumerable<RoleEntity> GetAllRoles();
    }
}
