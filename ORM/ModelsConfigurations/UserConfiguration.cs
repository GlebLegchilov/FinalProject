using ORM.Models;
using System.Data.Entity.ModelConfiguration;

namespace ORM.ModelsConfigurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        private const int MAX_LENGTH = 50;

        public UserConfiguration()
        {
            Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(MAX_LENGTH);

            Property(u => u.Name)
                .HasMaxLength(MAX_LENGTH);

            //Property(u => u.RegisrationDate)
                //.HasColumnType("datetime2")
                //.HasPrecision(0);

            //Property(u => u.Password)
            //    .IsRequired()
            //    .HasColumnType("binary")
            //    .HasMaxLength(32);


            HasRequired(u => u.Role)
                .WithMany()
                .WillCascadeOnDelete(false);

            HasMany(u => u.Lots)
               .WithRequired(p => p.Owner)
               .WillCascadeOnDelete(true);

            //HasMany(u=>u.Feedbacks)
            //    .WithRequired(f=>f.Creator)
            //    .WillCascadeOnDelete(true);

            //HasMany(u => u.Feedbacks)
            //    .WithRequired(f => f.Target)
            //    .WillCascadeOnDelete(true);

            HasMany(u => u.Auctions)
               .WithRequired(f => f.Creator)
               .WillCascadeOnDelete(true);

        }
    }
}
