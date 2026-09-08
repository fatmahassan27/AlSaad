using AlSaad.Application.DTOs;
using AlSaad.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlSaad.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockTransactionsController : ControllerBase
    {
        private readonly IStockTransactionService _stockTransactionService;

        public StockTransactionsController(IStockTransactionService stockTransactionService)
        {
            _stockTransactionService = stockTransactionService;
        }
        [HttpGet]
        public async Task<IActionResult> GetStockTransactions([FromQuery] StockTransactionQueryDto query, CancellationToken cancellationToken)
        {
            var result = await _stockTransactionService.GetStockTransactionsAsync(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetStockTransactionById(int id, CancellationToken cancellationToken)
        {
            var transaction = await _stockTransactionService.GetStockTransactionByIdAsync(id, cancellationToken);
            return transaction is null ? NotFound() : Ok(transaction);
        }
    }
}
