using ETradeAPI.Application.Repositories;
using ETradeAPI.Domain.Entities.Common;
using ETradeAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Persistence.Repositories
{
    public class WriteRepository<TEntity> : IWriteRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ETradeDbContext _dbContext;

        public WriteRepository(ETradeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<TEntity> Table => _dbContext.Set<TEntity>();

        public async Task<bool> AddAsync(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry = await Table.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<TEntity> entity)
        {
            await Table.AddRangeAsync(entity);
            return true;
        }

        public bool Delete(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry = Table.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            TEntity? entity = await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
            return Delete(entity!);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public bool Update(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry = Table.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }
    }
}
