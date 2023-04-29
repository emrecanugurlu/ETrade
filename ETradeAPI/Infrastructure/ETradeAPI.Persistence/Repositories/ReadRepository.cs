﻿using ETradeAPI.Application.Repositories;
using ETradeAPI.Domain.Entities.Common;
using ETradeAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Persistence.Repositories
{
    public class ReadRepository<TEntity> : IReadRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ETradeDbContext _dbContext;

        public ReadRepository(ETradeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<TEntity> Table => _dbContext.Set<TEntity>();

        public IQueryable<TEntity> GetAll(bool tracker = true) {
            IQueryable<TEntity> query = Table.AsQueryable();
            if (!tracker)
                query = Table.AsNoTracking();
            return query;
        }

        public async Task<TEntity> GetByIdAsync(string id, bool tracker = true)
        {
            IQueryable<TEntity> query = Table.AsQueryable();
            if (!tracker)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        }

        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> expression, bool tracker = true)
        {
            IQueryable<TEntity> query = Table.AsQueryable();
            if (!tracker)
                query = Table.AsNoTracking();
            TEntity? entity = await query.FirstOrDefaultAsync(expression);
            return entity;
        }
            

        public IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> expression, bool tracker = true)
        {
            IQueryable<TEntity> query = Table.AsQueryable();
            if (!tracker)
                query = Table.AsNoTracking();
            return query.Where(expression);
        }
            
    }
}
