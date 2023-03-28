using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Transactions;

namespace API.Controllers
{
    [Route("api/Category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        public CategoryController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        // GET: api/Category
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var category = await uow.CategoryRepository.GetCategory();
            return new OkObjectResult(category);
        }
        // GET: api/Category/5
        [HttpGet("{id}", Name = "GetC")]
        public IActionResult Get(int id)
        {
            var category = uow.CategoryRepository.GetCategoryById(id);
            return new OkObjectResult(category);
        }
        // POST: api/Category
        [HttpPost]
        public async Task<IActionResult>  Add(Category category)
        {
            uow.CategoryRepository.InsertCategory(category);
            await uow.SaveAsync();
            return StatusCode(201);
        }
        // PUT: api/Category/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put( Category category)
        {
            if (category != null)
            {
                uow.CategoryRepository.UpdateCategory(category);
                await uow.SaveAsync();
                return StatusCode(200);
            }
            return new NoContentResult();
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            uow.CategoryRepository.DeleteCategory(id);
            await uow.SaveAsync();
            return Ok(id);
        }
    }
}
