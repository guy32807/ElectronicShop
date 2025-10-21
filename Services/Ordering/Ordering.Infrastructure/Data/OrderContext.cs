using Microsoft.EntityFrameworkCore;
using Ordering.Core.Common;
using Ordering.Core.Entities;

namespace Ordering.Infrastructure.Data
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {

        }
        public DbSet<Order> Orders { get; set; }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries<EntityBase>())
            {
                switch (item.State)
                {
                    case EntityState.Added:
                        item.Entity.CreatedDate = DateTime.UtcNow;
                        item.Entity.CreatedBy = "To be replaced by auth server";
                        break;
                    case EntityState.Modified:
                        item.Entity.LastModifiedDate = DateTime.UtcNow;
                        item.Entity.LastModifiedBy = "To be replaced by auth server";
                        break;
                }
            }
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
