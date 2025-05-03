using AutoMapper;
using InterView_Task.DTOs.Product;
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
        private readonly IMapper _mapper;
        public ProductController(IProduct productRepository,
            IMapper mapper)
            
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllProducts()
        {
           List< Product> products = _productRepository.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            Product product = _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPost]
        public IActionResult CreateProduct([FromForm][FromBody] AddProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var product = _mapper.Map<Product>(productDto);
                    _productRepository.Add(product);
                    _productRepository.Save();
                    return Ok(product);

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.InnerException.Message);
                }
            }
            return BadRequest(ModelState); 
        }



        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromForm][FromBody] EditProductDto productDto)
        {
            if (ModelState.IsValid)
            {
              
                if (productDto != null)
                {
                    Product product = _productRepository.GetById(id);
                    _mapper.Map(productDto, product);

                    _productRepository.Update(product);
                    _productRepository.Save();
                    return NoContent();
                }
                ModelState.AddModelError("", "Invalid id");
            }
            return BadRequest(ModelState);
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
