using API.Dtos;
using API.Interfaces;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        public ProductController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        // GET: api/Product
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await uow.ProductRepository.GetProductsAsync();
            var productsDto = mapper.Map<IEnumerable<ProductDto>>(products);
            return new OkObjectResult(productsDto);
        }
        // GET: api/Product/5
        [HttpGet, Route("{id}", Name = "GetP")]
        public IActionResult Get(int id)
        {
            var product = uow.ProductRepository.GetProductById(id);
            var productDto = mapper.Map<ProductDto>(product);
            return new OkObjectResult(productDto);
        }
        // POST: api/Product
        [HttpPost]
        public async Task<IActionResult> Add(ProductDto productDto)
        {
            var product = mapper.Map<Product>(productDto);
            product.LastUpdatedOn = DateTime.Now;
            uow.ProductRepository.InsertProduct(product);
            await uow.SaveAsync();
            return StatusCode(201);
        }
        // PUT: api/Product/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put( ProductDto productDto)
        {
            if (productDto != null)
            {
                var product = mapper.Map<Product>(productDto);
                product.LastUpdatedOn = DateTime.Now;
                uow.ProductRepository.UpdateProduct(product);
                await uow.SaveAsync();
                return StatusCode(200);
            }
            return new NoContentResult();
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            uow.ProductRepository.DeleteProduct(id);
            await uow.SaveAsync();
            return Ok(id);
        }
    }
}
