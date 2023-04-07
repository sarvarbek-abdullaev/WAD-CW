using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Transactions;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        public ProductController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        // GET: api/Product
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var product = await uow.ProductRepository.GetProducts();
            

            return new OkObjectResult(product);
        }
        // GET: api/Product/5
        [HttpGet("{id}", Name = "GetP")]
        public IActionResult Get(int id)
        {
            var product = uow.ProductRepository.GetProductById(id);
            if (product == null) return BadRequest("Not available ID written");

            return new OkObjectResult(product);
        }
        // POST: api/Product
        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            if (product == null) return BadRequest("Category cannot be null");

            uow.ProductRepository.InsertProduct(product);
            await uow.SaveAsync();
            return StatusCode(201);
        }
        // PUT: api/Product/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Product product)
        {
            if (product != null)
            {
                uow.ProductRepository.UpdateProduct(product);
                await uow.SaveAsync();
                if (id != product.ID || product == null) return BadRequest("Update Not Allowed");

                return StatusCode(200);
            }
            return new NoContentResult();
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = uow.ProductRepository.GetProductById(id);
            if (product == null) return BadRequest("Delete Not Allowed, Reason: Not available ID written");

            uow.ProductRepository.DeleteProduct(id);
            await uow.SaveAsync();
            return Ok(id);
        }
    }
}
