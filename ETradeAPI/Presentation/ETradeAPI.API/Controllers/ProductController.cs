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
        public async Task GetAllProduct()
        {
            //await _productWriteRepository.AddAsync(new Product() { Name = "Kemer",Stock = 12,Price = 130,Description = "Orjinal deri."});
            

            _productWriteRepository.Update(new() { Id = Guid.Parse("86F54D98-9F8D-40FE-DD8A-08DB494BFC8D"),Name ="Kemer 2",Description = "123"});
            await _productWriteRepository.SaveChangesAsync();

        }
   
    }
}
