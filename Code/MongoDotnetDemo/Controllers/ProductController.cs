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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var product = await _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Product product)
        {
            product.CategoryName = null;
            await _productService.CreateAsync(product);
            return Ok("Created successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Product newProduct)
        {
            newProduct.CategoryName = null;
            var product = await _productService.GetById(id);
            if (product == null)
                return NotFound();
            await _productService.UpdateAsync(id, newProduct);
            return Ok("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var product = await _productService.GetById(id);
            if (product == null)
                return NotFound();
            await _productService.DeleteAsync(id);
            return Ok("Deleted Successfully");
        }
    }
}