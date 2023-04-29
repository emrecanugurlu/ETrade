using ETradeAPI.Application.Repositories.AbstractProduct;
using ETradeAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETradeAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public ProductController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpGet]
        public IActionResult GetAllProduct()
        {
            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Description = string.Empty,
                    Name = string.Empty,
                    CreatedDate = DateTime.Now,
                    Price = 0,
                    Stock = 13
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Description = string.Empty,
                    Name = string.Empty,
                    CreatedDate = DateTime.Now,
                    Price = 0,
                    Stock = 13
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Description = string.Empty,
                    Name = string.Empty,
                    CreatedDate = DateTime.Now,
                    Price = 0,
                    Stock = 13
                }

            };

            _productWriteRepository.AddRangeAsync(products);
            _productWriteRepository.SaveChangesAsync();

            return Ok(products);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(string id) {

            Product p = await _productReadRepository.GetByIdAsync(id);

            return Ok(p);
        }
    }
}
