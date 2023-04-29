using ETradeAPI.Application.Abstractions;
using ETradeAPI.Domain.Entities;
using ETradeAPI.Persistence.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETradeAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAllProduct()
        {
            List<Product> s =_productService.GetProducts();
            return Ok(s);
        }
    }
}
