
using challengePaggcerto.src.api.Models.EntityModel;
using Microsoft.AspNetCore.Mvc;

namespace challengePaggcerto.src.api.Models.ResultModel
{
    public class ListTransactionJson : IActionResult
    {
        public int Count {get; set;}
        public ICollection<TransactionJson>? Transactions {get; set;}

        public ListTransactionJson(ICollection<Transaction> transactions)
        {
            this.Transactions = transactions.Select(t => new TransactionJson(t)).ToList();
            this.Count = this.Transactions.Count();
        }
        public Task ExecuteResultAsync(ActionContext context)
        {
            return new JsonResult(this).ExecuteResultAsync(context);
        }
    }

}