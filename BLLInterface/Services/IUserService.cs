using System.Collections.Generic;
using BLLInterface.Entities;

namespace BLLInterface.Services
{
    public interface IUserService:IService<UserEntity>
    {
        UserEntity GetUserEntityByName(string name);
        void CreateUser(UserEntity user);
        void DeleteUser(UserEntity user);
    }
}
