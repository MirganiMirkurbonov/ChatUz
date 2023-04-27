using Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.RootContext;

public class AuthUserConfiguration : IEntityTypeConfiguration<AuthUser>
{
    public void Configure(EntityTypeBuilder<AuthUser> builder)
    {
        builder.HasIndex(x => x.Email);
        builder.HasIndex(x => x.PhoneNumber);
        builder.HasQueryFilter(x => x.State != Domain.Enums.State.Deleted);
    }
}
