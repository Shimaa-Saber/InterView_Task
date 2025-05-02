using AutoMapper;
using InterView_Task.DTOs.Transaction;
using InterView_Task.Interfaces;
using InterView_Task.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace InterView_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransaction _transactionRepository;
        private readonly IMapper _mapper;
        private readonly IProduct _productRepository;
        public TransactionController(ITransaction transactionRepository,
            IMapper mapper,
            IProduct productRepository)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddStock([FromBody] AddStockDto dto)
        {
          
            Product product =  _productRepository.GetById(dto.ProductId);
            if (product == null) return NotFound("Product not found");

            product.Quantity += dto.Quantity;
            _productRepository.Update(product);

           
            var transactionDto = _mapper.Map<TransactionDto>(dto);
            _transactionRepository.AddTransaction(transactionDto, User.FindFirstValue(ClaimTypes.NameIdentifier));

            
             _transactionRepository.Save();

            return Ok(new { product.Quantity });
        }


        [HttpPost("remove")]
        public async Task<IActionResult> RemoveStock([FromBody] RemoveStockDto dto)
        {
            Product product = _productRepository.GetById(dto.ProductId);
            if (product == null) return NotFound("Product not found");
            if (product.Quantity < dto.Quantity) return BadRequest("Not enough stock");
            product.Quantity -= dto.Quantity;
            _productRepository.Update(product);

            var transactionDto = _mapper.Map<TransactionDto>(dto);
            _transactionRepository.AddTransaction(transactionDto, User.FindFirstValue(ClaimTypes.NameIdentifier));

            _transactionRepository.Save();
            return Ok(new { product.Quantity });
        }




        [HttpPost("transfer")]
        public async Task<IActionResult> TransferStock(
            [FromBody] TransferStockDto request)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                _transactionRepository.TransferStock(request, userId);

                return Ok(new
                {
                    Message = "Stock transferred successfully",
                   
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }





    }
}
