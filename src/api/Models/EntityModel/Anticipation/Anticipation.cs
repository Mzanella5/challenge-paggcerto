

namespace challengePaggcerto.src.api.Models.EntityModel
{
    public class Anticipation
    {
        public long Id { get; set;}
        public DateTime? RequestDate { get; set;}
        public DateTime? StartAnalysisDate { get; set;}
        public DateTime? FinalAnalysisDate { get; set;}
        public int AnalysisState { get; set;}
        public double AnticipatedRequiredValue { get; set;}
        public double AnticipatedValue { get; set;}
        public ICollection<Transaction>? Transactions { get; set;}

    }
}