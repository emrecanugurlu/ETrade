using ETradeAPI.Domain.Entities;
using ETradeAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Persistence.Contexts
{
    public class ETradeDbContext : DbContext
    {
        public ETradeDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }



        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var a = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in a)
            {
                switch (data.State)
                {
                    case EntityState.Added:
                        data.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        data.Entity.UpdatedDate = DateTime.Now;
                        break;
                    default:
                        break;
                }

            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
