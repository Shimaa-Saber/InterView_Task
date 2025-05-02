using InterView_Task.Interfaces;
using InterView_Task.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterView_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _productRepository;
        public ProductController(IProduct productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _productRepository.GetAll();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            _productRepository.Add(product);
            _productRepository.Save();
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product product)
        {
            if (id != product.Id || product == null)
            {
                return BadRequest();
            }
            _productRepository.Update(product);
            _productRepository.Save();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            _productRepository.Delete(product);
            _productRepository.Save();
            return NoContent();
        }

    }
}
