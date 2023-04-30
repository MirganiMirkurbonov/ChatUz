using Domain.Entities.Auth;
using Domain.Enums.Status;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations;

public class AuthUsernameConfiguration : IEntityTypeConfiguration<AuthUsername>
{
    public void Configure(EntityTypeBuilder<AuthUsername> builder)
    {
        builder.HasIndex(x => x.Username).IsUnique();
        builder.HasQueryFilter(x => x.State != State.Deleted);
    }
}
