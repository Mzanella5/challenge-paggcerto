using System.ComponentModel.DataAnnotations;
using challengePaggcerto.src.api.Models.EntityModel;
using Newtonsoft.Json;

namespace challengePaggcerto.src.api.Models.ViewModel
{
    public class ListTransactionModel
    {
        [Display(Name = "TransactionModels"), JsonRequired, MinLength(1)]
        public ICollection<TransactionModel>? TransactionModels {get; set;}
        public List<Transaction> Map()
        {
            return this.TransactionModels!.Select(t => t.Map()).ToList();
        }
    }
    
}