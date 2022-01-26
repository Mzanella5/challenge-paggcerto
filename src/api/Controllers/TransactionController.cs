using challengePaggcerto.src.api.Models.EntityModel;
using Microsoft.AspNetCore.Mvc;
using challengePaggcerto.src.api.Models.ResultModel;
using challengePaggcerto.src.api.Models.ServiceModel;
using challengePaggcerto.src.api.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet, Route("request-anticipations")]
        public async Task<IActionResult> RequestAnticipation(ListTransactionModel transactionModel)
        {
            //for the best practice I need to take the data from the database using id of transaction but found some dificults
            var result = await _transactionService.RequestAnticipation(_context,transactionModel.Map());
            if(result)
                return Ok(new { message = "Success: Done."});

            return BadRequest(new { message = "Erro: Some problem happned while processing the request."});
        }

    }

}
