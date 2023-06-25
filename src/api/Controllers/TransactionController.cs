using challengePaggcerto.src.api.Models.EntityModel;
using Microsoft.AspNetCore.Mvc;
using challengePaggcerto.src.api.Models.ResultModel;
using challengePaggcerto.src.api.Models.ServiceModel;
using challengePaggcerto.src.api.Models.ViewModel;

namespace challengePaggcerto.src.api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly TransactionService _transactionService;
        public TransactionController(DataContext context, TransactionService transactionService)
        {
            this._context = context;
            this._transactionService = transactionService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransaction(long id)
        {
            var tResult = await _transactionService.GetTransactionByIdAsync(_context,id);
            return new TransactionJson(tResult!);
        }

        [HttpPost]
        public async Task<IActionResult> PostTransaction(TransactionModel transaction)
        {
            var status = await _transactionService.AddTransactionAsync(_context,transaction.Map());
            // connect to the bank api to process the transaction.CreditCard
            if(status)
                return Ok(new { message = "Success: Done."});
            return BadRequest(new { message = "Erro: Some problem happned while processing the request."});

        }

        [HttpGet, Route("allowed-to-anticipate")]
        public async Task<IActionResult> GetAllowedTransactions()
        {
            var transactions = await _transactionService.GetAllowedTransactionsAsync(_context);
            return new ListTransactionJson(transactions!);
        }

    }
}
