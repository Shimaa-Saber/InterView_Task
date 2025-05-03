using InterView_Task.Interfaces;
using InterView_Task.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterView_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportingController : ControllerBase

    {
        private readonly IReport _reportRepository;
        public ReportingController(IReport reportRepository)
        {
            _reportRepository = reportRepository;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("low-stock")]
        public async Task<IActionResult> GetLowStockReport(
        [FromQuery] string? category = null,
        [FromQuery] bool includeOutOfStock = false)
        {
            var results = await _reportRepository.GetLowStockReportAsync(category, includeOutOfStock);
            return Ok(results);
        }

        [Authorize(Roles = "Admin")]

        [HttpGet("transaction-history")]
        public async Task<IActionResult> GetTransactionHistory(
            [FromQuery] int? productId = null,
            [FromQuery] DateTime? startDate = null,
            [FromQuery] DateTime? endDate = null,
            [FromQuery] string? transactionType = null)
        {
            var result = await _reportRepository.GetTransactionHistoryAsync(
                productId,
                startDate,
                endDate,
                transactionType
              
              );

            return Ok(result);
        }

    }
}
