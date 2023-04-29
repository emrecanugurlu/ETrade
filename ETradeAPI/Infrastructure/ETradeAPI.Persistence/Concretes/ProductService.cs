using ETradeAPI.Application.Abstractions;
using ETradeAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Persistence.Concretes
{
    public class ProductService : IProductService
    {
        public List<Product> GetProducts()
        {
            return new()
            {
                new()
                {
                    Id = new Guid(),
                    Name = "Product 1",
                    Description = "qwertyuı",
                    Stock = 12,
                    CreatedDate = DateTime.Now.Date,

                },
                new()
                {
                    Id = new Guid(),
                    Name = "Product 2",
                    Description = "qwertyuı",
                    Stock = 12,
                    CreatedDate = DateTime.Now.Date,

                },
                new()
                {
                    Id = new Guid(),
                    Name = "Product 3",
                    Description = "qwertyuı",
                    Stock = 12,
                    CreatedDate = DateTime.Now.Date,

                }
            };
        }
    }
}
