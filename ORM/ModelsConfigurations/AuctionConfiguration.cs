using ORM.Models;
using System.Data.Entity.ModelConfiguration;

namespace ORM.ModelsConfigurations
{
    public class AuctionConfiguration : EntityTypeConfiguration<Auction>
    {
        public AuctionConfiguration()
        {
            Property(u => u.Type)
                .IsRequired();
                

            //Property(u => u.EndingDate)
            //.HasColumnType("datetime2")
            //.HasPrecision(0);


            //HasMany(u => u.Lots)
            //    .WithRequired(l=>l.Auction)
            //    .WillCascadeOnDelete(false);


        }
    }
}
