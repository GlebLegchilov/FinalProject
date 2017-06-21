using System.Collections.Generic;
using BLLInterface.Entities;

namespace BLLInterface.Services
{
    public interface IUserService:IService<UserEntity>
    {
        UserEntity GetByName(string name);
        int GetUserId(string name);
        void CreateUser(UserEntity user);
        void DeleteUser(UserEntity user);
        bool Exist(string name);

    }
}
