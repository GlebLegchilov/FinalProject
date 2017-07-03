using ORM.Models;
using System.Data.Entity.ModelConfiguration;

namespace ORM.ModelsConfigurations
{
    public class LotConfiguration : EntityTypeConfiguration<Lot>
    {
        private const int MAX_LENGTH = 50;

        public LotConfiguration()
        {
            Property(l =>l.Name)
                .IsRequired()
                .HasMaxLength(MAX_LENGTH);

            Property(u => u.Description)
                .IsRequired();

            Property(l => l.AuctionId)
                .IsOptional();
            

            //HasRequired(c => c.Auction)
            //    .WithMany(t => t.Lots)
            //    .WillCascadeOnDelete(true);
        }
    }
}