namespace ORM
{
    using System;
    using System.Data.Entity;
    using System.Linq;

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
        public virtual DbSet<Category> Categorys { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);
        }


    }
}