using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDotnetDemo.Models;
using MongoDotnetDemo.Services;

namespace MongoDotnetDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var category = await _categoryService.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Category category)
        {
            await _categoryService.CreateAsync(category);
            return Ok("Created successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Category newCategory)
        {
            var category = await _categoryService.GetById(id);
            if (category == null)
                return NotFound();
            await _categoryService.UpdateAsync(id, newCategory);
            return Ok("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var category = await _categoryService.GetById(id);
            if (category == null)
                return NotFound();
            await _categoryService.DeleteAsync(id);
            return Ok("Deleted Successfully");
        }
    }
}