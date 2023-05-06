﻿using ETradeAPI.Application.Repositories.AbstractProduct;
using ETradeAPI.Application.ViewModel;
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
        public IActionResult Get()
        {

            //_productWriteRepository.AddAsync(new()
            //{
            //    Name = "name",
            //    Description = "description",
            //    Price = 12,
            //    Stock = 12,
            //});
            _productWriteRepository.SaveChangesAsync();

            IQueryable<Product> products = _productReadRepository.GetAll(tracker:false);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id) {
            var product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task Post(ProductCreateViewModel productCreateViewModel)
       
        {
            if (ModelState.IsValid)
            {
                
            }
            await _productWriteRepository.AddAsync(new() {
                Name = productCreateViewModel.Name,
                Description = productCreateViewModel.Description,
                Stock = productCreateViewModel.Stock,
                Price = productCreateViewModel.Price,
            });
            await _productWriteRepository.SaveChangesAsync();

        }

        [HttpPut]
        public async Task Put(ProductUpdateViewModel productUpdateViewModel)
        {
            Product product = await _productReadRepository.GetByIdAsync(productUpdateViewModel.Id);
            product.Stock = productUpdateViewModel.Stock;
            product.Price = productUpdateViewModel.Price;
            product.Description = productUpdateViewModel.Description;
            product.Name = productUpdateViewModel.Name;
            await _productWriteRepository.SaveChangesAsync();
        }

        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await _productWriteRepository.DeleteAsync(id);
            await _productWriteRepository.SaveChangesAsync();
        }
    }
}
