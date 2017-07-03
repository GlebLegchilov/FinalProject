using System.Collections.Generic;
using BLLInterface.Entities;

namespace BLLInterface.Services
{
    public interface IUserService
    {
   
        UserEntity GetUser(int id);

        UserEntity GetUser(string name);

        IEnumerable<UserEntity> GetAllUsers();

        int GetUserId(string name);

        void CreateUser(UserEntity user);

        void DeleteUser(int id);

        void UpdateUser(UserEntity user);

        bool IsExist(int id);

        bool IsExist(string name);

    }
}
