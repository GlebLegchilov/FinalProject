using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BLLInterface.Entities;
using BLLInterface.Services;
using BLL.Mappers;
using DALInterface.Repository;
using System.Linq.Expressions;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork uow;

        public UserService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void CreateUser(UserEntity user)
        {
            uow.Users.Create(user.ToDalUser());
            uow.Commit();
        }

        public void DeleteUser(int id)
        {
            uow.Users.Delete(id);
            uow.Commit();
        }
        public void UpdateUser(UserEntity user)
        {
            uow.Users.Update(user.ToDalUser());
            uow.Commit();
        }

        //public bool Exist(Expression<Func<TDalEntity, bool>> predicate)
        //{
        //    return uow.Users.Exist(predicate);
        //}

        public IEnumerable<UserEntity> GetAllUsers()
        {
            return uow.Users.GetByPredicate(u => true)
                .Select(u => u.ToBllUser());
        }

        public UserEntity GetUser(string name)
        {
            return uow.Users.GetByPredicate(u => u.Name == name)
               .First()
               .ToBllUser();
        }

        public UserEntity GetUser(int id)
        {
            return uow.Users.GetByPredicate(u => u.Id == id)
                .First()
                .ToBllUser();
        }

        public int GetUserId(string name)
        {
            return uow.Users.GetByPredicate(u => u.Name == name)
              .First()
              .ToBllUser()
              .Id; 
        }

        public bool IsExist(int id)
        {
            return uow.Users.Exist(u=>u.Id==id);
        }
        public bool IsExist(string name )
        {
            return uow.Users.Exist(u => u.Name == name);
        }
    }
}
