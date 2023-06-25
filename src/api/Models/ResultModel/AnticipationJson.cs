using challengePaggcerto.src.api.Models.EntityModel;
using Microsoft.AspNetCore.Mvc;

namespace challengePaggcerto.src.api.Models.ResultModel
{
    public class AnticipationJson : IActionResult
    {
        public long Id { get; set;}
        public DateTime? RequestDate { get; set;}
        public DateTime? StartAnalysisDate { get; set;}
        public DateTime? FinalAnalysisDate { get; set;}
        public EAnticipationStatus AnalysisState { get; set;}
        public double AnticipatedRequiredValue { get; set;}
        public double AnticipatedValue { get; set;}
        public ICollection<Transaction>? Transactions { get; set;}

        public Task ExecuteResultAsync(ActionContext context)
        {
            throw new NotImplementedException();
        }
    }
}