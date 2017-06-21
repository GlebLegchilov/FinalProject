using System;
using System.Data.Entity;
using System.Diagnostics;
using DALInterface.Repository;
using DALInterface.DTO;

namespace DAL.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        #region private repository fields

        private IUserRepository userRepository;
        private IRepository<DalRole> roleRepository;
        private IRepository<DalLot> lotRepository;
        private IRepository<DalCategory> categoryRepository;
        #endregion

        public UnitOfWork(DbContext context)
        {
            Context = context;
        }

        public DbContext Context { get; }

        #region Repository Properties

        public IUserRepository Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(Context);
                return userRepository;
            }
        }
        public IRepository<DalRole> Roles
        {
            get
            {
                if (roleRepository == null)
                    roleRepository = new RoleRepository(Context);
                return roleRepository;
            }
        }
        public IRepository<DalLot> Lots
        {
            get
            {
                if (lotRepository == null)
                    lotRepository = new LotRepository(Context);
                return lotRepository;
            }
        }
        public IRepository<DalCategory> Categorys
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository(Context);
                return categoryRepository;
            }
        }
      
        #endregion

        public void Commit()
        {
            if (Context != null)
            {
                Context.SaveChanges();
                
            }
        }

        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
        }
    }
}
