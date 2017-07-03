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

        private IRepository<DalUser> userRepository;
        private IRepository<DalRole> roleRepository;
        private IRepository<DalLot> lotRepository;
        private IRepository<DalAuction> auctionRepository;
        private IRepository<DalFeedback> feedbackRepository;
        private IRepository<DalRate> rateRepository;
        #endregion

        public UnitOfWork(DbContext context)
        {
            Context = context;
        }

        public DbContext Context { get; }

        #region Repository Properties

        public IRepository<DalUser> Users
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
        

        public IRepository<DalAuction> Auctions
        {
            get
            {
                if (auctionRepository == null)
                    auctionRepository = new AuctionRepository(Context);
                return auctionRepository;
            }
        }
        
        public IRepository<DalFeedback> Feedbacks
        {
            get
            {
                if (feedbackRepository == null)
                    feedbackRepository = new FeedbackRepository(Context);
                return feedbackRepository;
            }
        }

        public IRepository<DalRate> Rates
        {
            get
            {
                if (rateRepository == null)
                    rateRepository = new RateRepositiry(Context);
                return rateRepository;
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
