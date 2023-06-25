using challengePaggcerto.src.api.Models.EntityModel;
using Microsoft.AspNetCore.Mvc;
using challengePaggcerto.src.api.Models.ResultModel;
using challengePaggcerto.src.api.Models.ServiceModel;
using challengePaggcerto.src.api.Models.ViewModel;

namespace challengePaggcerto.src.api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AnticipationController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly AnticipationService _anticipationService;
        public AnticipationController(DataContext context, AnticipationService anticipationService)
        {
            this._context = context;
            this._anticipationService = anticipationService;
        }

        [HttpGet, Route("request-anticipation")]
        public async Task<IActionResult> RequestAnticipation(ListTransactionModel transactions)
        {
            List<Transaction> list;
            if(transactions.TransactionModels == null)
                return BadRequest(new { message = "Erro: None transaction received."});

            list = _context.Transactions!.WhereTransactionIds(transactions.Map()).ToList();

            var result = await _anticipationService.RequestAnticipation(_context, list);
            if(result!.Count > 0)
                return new ListTransactionJson(result);

            return BadRequest(new { message = "Erro: None of the transactions received can be anticipated."});
        }

        [HttpGet, Route("start-analyzing")]
        public async Task<IActionResult> StartAnalyzingAnticipations(ListAnticipationModel anticipations)
        {
            if(anticipations.AnticipationModels == null)
                return BadRequest(new { message = "Erro: None anticipations received."});
                
            var result = await _anticipationService.AnalyzingAnticipations(_context, anticipations.Map());

            if(result.Count > 0)
                return Ok(result);

            return BadRequest(new { message = "Erro: None of the anticipations received can be analyzed or they are already in analysis process."});
        }

        
        [HttpPost, Route("conclude-analyzing")]
        public async Task<IActionResult> ConcludeAnalyzingTransactions(ListIdsModel ids)
        {
            try
            {
                return Ok(ids);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return BadRequest("Erro: Something unexpected happened.");
            }
        }
    }
 
}
