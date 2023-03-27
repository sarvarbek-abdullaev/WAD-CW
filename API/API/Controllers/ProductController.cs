using API.Models;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Transactions;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        // GET: api/Product
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productRepository.GetProducts();
            return new OkObjectResult(products);
        }
        // GET: api/Product/5
        [HttpGet, Route("{id}", Name = "GetP")]
        public IActionResult Get(int id)
        {
            var product = _productRepository.GetProductById(id);
            return new OkObjectResult(product);
            //return "value";
        }
        // POST: api/Product
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            using (var scope = new TransactionScope())
            {
                _productRepository.InsertProduct(product);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = product.ID }, product);
            }
        }
        // PUT: api/Product/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Product product)
        {
            if (product != null)
            {
                using (var scope = new TransactionScope())
                {
                    _productRepository.UpdateProduct(product);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productRepository.DeleteProduct(id);
            return new OkResult();
        }
    }
}
