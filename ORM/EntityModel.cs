using System;
using System.Data.Entity;
using System.Linq;
using ORM.Models;
using ORM.ModelsConfigurations;

namespace ORM
{
   

    public partial class EntityModel : DbContext
    {
        public EntityModel()
            : base("name=AuctionDB")
        {
            Database.SetInitializer(new DBContextInitialize());
        }

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Lot> Lots { get; set; }
        public virtual DbSet<Rate> Rates { get; set; }
        public virtual DbSet<Auction> Auctions { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new FeedbackConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new LotConfiguration());
            modelBuilder.Configurations.Add(new AuctionConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new RateConfiguration());
        }


    }
}