using ORM.Models;
using System.Data.Entity.ModelConfiguration;

namespace ORM.ModelsConfigurations
{
    public class FeedbackConfiguration : EntityTypeConfiguration<Feedback>
    {
        public FeedbackConfiguration()
        {
            Property(u => u.Text)
                .IsRequired();


            //HasOptional(c => c.Creator)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);

            //HasRequired(c => c.Target)
            //    .WithMany(t => t.Feedbacks)
            //    .WillCascadeOnDelete(true);
        }
    }
}
