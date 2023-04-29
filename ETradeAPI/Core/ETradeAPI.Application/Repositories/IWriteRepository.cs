using ETradeAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Repositories
{
    public interface IWriteRepository<TEntity>:IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<bool> AddAsync(TEntity entity);
        Task<bool> AddRangeAsync(List<TEntity> entity);
        bool Delete(TEntity entity);
        Task<bool> DeleteAsync(string id);
        bool Update(TEntity entity);
        Task<int> SaveChangesAsync();
    }
}
