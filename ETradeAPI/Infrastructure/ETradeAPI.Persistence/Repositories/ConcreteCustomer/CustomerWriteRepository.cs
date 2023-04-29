using ETradeAPI.Application.Repositories.AbstractCustomer;
using ETradeAPI.Domain.Entities;
using ETradeAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Persistence.Repositories.ConcreteCustomer
{
    internal class CustomerWriteRepository : WriteRepository<Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(ETradeDbContext dbContext) : base(dbContext)
        {
        }
    }
}
