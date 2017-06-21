using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BLLInterface.Entities;
using BLLInterface.Services;
using BLL.Mappers;
using DALInterface.Repository;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork uow;

        public UserService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public UserEntity GetById(int id)
        {
            return uow.Users.GetById(id).ToBllUser();
        }
        public bool Exist(string name)
        {
            return uow.Users.Exist(uow.Users.GetByName(name));
        }
        public bool Exist(UserEntity c)
        {
            return uow.Users.Exist(c.ToDalUser());
        }

        public UserEntity GetByName(string name)
        {

            return uow.Users.GetByName(name).ToBllUser();
        }
        public int GetUserId(string name)
        {
            return uow.Users.GetByName(name).ToBllUser().Id;
        }

        public IEnumerable<UserEntity> GetAll()
        {
            return uow.Users.GetAll().Select(user => user.ToBllUser());
        }

        public void CreateUser(UserEntity user)
        {
            uow.Users.Create(user.ToDalUser());
            uow.Commit();
        }

        public void DeleteUser(UserEntity user)
        {
            uow.Users.Delete(user.ToDalUser());
            uow.Commit();
        }
    }
}
