using System;
using ORM.Models;
using System.Data.Entity.ModelConfiguration;

namespace ORM.ModelsConfigurations
{
    public class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        private const int MAX_LENGTH = 50;

        public RoleConfiguration()
        {
            Property(u => u.Name)
               .IsRequired()
               .HasMaxLength(MAX_LENGTH);

            HasMany(e => e.Users)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);
        }
    }
}
