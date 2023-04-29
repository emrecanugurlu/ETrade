using ETradeAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Repositories
{
    public interface IReadRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetAll(bool tracker = true);
        IQueryable<TEntity> GetWhere(Expression<Func<TEntity,bool>> expression, bool tracker = true);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> expression, bool tracker = true);
        Task<TEntity> GetByIdAsync(string id, bool tracker = true);
    }
}
