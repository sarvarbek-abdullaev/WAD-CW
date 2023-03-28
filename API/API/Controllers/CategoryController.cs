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
    [Route("api/Category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        public CategoryController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        // GET: api/Category
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var category = await uow.CategoryRepository.GetCategory();
            var categoryDto = mapper.Map<IEnumerable<CategoryDto>>(category);
            return new OkObjectResult(categoryDto);
        }
        // GET: api/Category/5
        [HttpGet("{id}", Name = "GetC")]
        public async Task<IActionResult> Get(int id)
        {
            var category = await uow.CategoryRepository.GetCategoryById(id);
            var categoryDto = mapper.Map<CategoryDto>(category);
            return new OkObjectResult(categoryDto);
        }
        // POST: api/Category
        [HttpPost]
        public async Task<IActionResult> Add(CategoryDto categoryDto)
        {
            var category = mapper.Map<Category>(categoryDto);
            category.LastUpdatedOn = DateTime.Now;
            uow.CategoryRepository.InsertCategory(category);
            await uow.SaveAsync();
            return StatusCode(201);
        }
        // PUT: api/Category/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Category categoryDto)
        {
            if (categoryDto != null)
            {
                var categoryFromDb = await uow.CategoryRepository.GetCategoryById(id);
                categoryFromDb.LastUpdatedOn = DateTime.Now;
                mapper.Map(categoryDto, categoryFromDb);

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
