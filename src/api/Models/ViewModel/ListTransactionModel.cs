using challengePaggcerto.src.api.Models.EntityModel;

namespace challengePaggcerto.src.api.Models.ViewModel
{
    public class ListTransactionModel
    {
        public ICollection<TransactionModel>? TransactionModels {get; set;}
        public ICollection<Transaction> Map()
        {
            return this.TransactionModels!.Select(t => t.Map()).ToList();
        }
    }
    
}