using DotNetCoreAngular.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreAngular.Persistence.Configurations
{
    public class UserExtensionsConfiguration : IEntityTypeConfiguration<UserExtensions>
    {
        public void Configure(EntityTypeBuilder<UserExtensions> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasMany(x => x.Users)
             .WithOne(x => x.UserExtensions)
             .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
