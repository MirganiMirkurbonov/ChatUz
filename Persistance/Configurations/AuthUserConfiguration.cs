using Domain.Entities.Auth;
using Domain.Enums;
using Domain.Enums.Status;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations;

public class AuthUserConfiguration : IEntityTypeConfiguration<AuthUser>
{
    public void Configure(EntityTypeBuilder<AuthUser> builder)
    {
        builder.HasIndex(x => x.PhoneHash).IsUnique().HasFilter("phone_hash IS NOT NULL");
        builder.HasIndex(x => x.EmailHash).IsUnique().HasFilter("email_hash IS NOT NULL");
        builder.HasQueryFilter(x => x.State != State.Deleted);
    }
}
