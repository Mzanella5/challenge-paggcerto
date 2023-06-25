using System.ComponentModel.DataAnnotations;
using challengePaggcerto.src.api.Models.EntityModel;
using Newtonsoft.Json;

namespace challengePaggcerto.src.api.Models.ViewModel
{
    public class AnticipationModel
    {
        [Display(Name = "Id"), JsonRequired]
        public long Id { get; set;}
        public DateTime? RequestDate { get; set;}
        public DateTime? StartAnalysisDate { get; set;}
        public DateTime? FinalAnalysisDate { get; set;}
        public EAnticipationStatus AnalysisState { get; set;}
        public double AnticipatedRequiredValue { get; set;}
        public double AnticipatedValue { get; set;}
        public ICollection<Transaction>? Transactions { get; set;}

        public Anticipation Map()
        {
            return new Anticipation
            {
               Id = this.Id,
               RequestDate = this.RequestDate,
               StartAnalysisDate = this.StartAnalysisDate,
               FinalAnalysisDate = this.FinalAnalysisDate,
               AnalysisState = this.AnalysisState,
               AnticipatedRequiredValue = this.AnticipatedRequiredValue,
               AnticipatedValue = this.AnticipatedValue,
               Transactions = this.Transactions 
            };
        }

    }
}