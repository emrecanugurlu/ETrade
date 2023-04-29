using ETradeAPI.Application.Repositories.AbstractOrder;
using ETradeAPI.Domain.Entities;
using ETradeAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Persistence.Repositories.ConcreteOrder
{
    internal class OrderWriteRepository : WriteRepository<Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(ETradeDbContext dbContext) : base(dbContext)
        {
        }
    }
}
