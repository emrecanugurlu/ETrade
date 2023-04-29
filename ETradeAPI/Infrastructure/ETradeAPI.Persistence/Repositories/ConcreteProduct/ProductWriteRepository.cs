using ETradeAPI.Application.Repositories.AbstractProduct;
using ETradeAPI.Domain.Entities;
using ETradeAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Persistence.Repositories.ConcreteProduct
{
    internal class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(ETradeDbContext dbContext) : base(dbContext)
        {
        }
    }
}
