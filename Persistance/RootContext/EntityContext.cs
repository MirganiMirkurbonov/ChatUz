using Domain.Entities.Common;
using Domain.Enums.Status;
using Microsoft.EntityFrameworkCore;
using Persistance.Configurations;

namespace Persistance.RootContext;

public partial class EntityContext : DbContext
{
    public static string? ConnectionString { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="optionsBuilder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      => optionsBuilder.UseNpgsql(ConnectionString,
          builder => { builder.EnableRetryOnFailure(3, TimeSpan.FromSeconds(2), null); });

    /// <summary>
    /// 
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AuthUserConfiguration());
        modelBuilder.ApplyConfiguration(new AuthUsernameConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override int SaveChanges()
    {
        foreach (var entity in ChangeTracker.Entries<EntityTracked<long>>())
        {
            if (entity.State == EntityState.Added)
            {
                entity.Entity.CreatedAt = DateTime.UtcNow;
                entity.Entity.State = State.Created;
            }
            if (entity.State == EntityState.Modified)
            {
                entity.Entity.UpdatedAt = DateTime.UtcNow;
                entity.Entity.State = State.Updated;
            }
            if(entity.State == EntityState.Deleted)
            {
                entity.Entity.State = State.Deleted;
                entity.Entity.UpdatedAt = DateTime.UtcNow;
            }
        }
        return base.SaveChanges();
    }
}
