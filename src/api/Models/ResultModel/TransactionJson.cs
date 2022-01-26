using challengePaggcerto.src.api.Models.EntityModel;
using Microsoft.AspNetCore.Mvc;

namespace challengePaggcerto.src.api.Models.ResultModel
{
    public class TransactionJson : IActionResult
    {
        public long Id { get; set; }
        public DateTime DateExecuted { get; set; }
        public DateTime? DateAccepted { get; set; }
        public DateTime? DateRejected { get; set; }
        public bool Anticipated { get; set; }
        public bool AcquirerConfirm { get; set; }
        public double GrossValue { get; set; }
        public double NetValue { get; set; }
        public double FixRate { get; set; }
        public int ParcelAmount { get; set; }
        public string? LastFourCardDigits { get; set; }
        public ICollection<Parcel>? Parcels { get; set; }
        public TransactionJson(Transaction transaction)
        {
            Id = transaction.Id;
            DateExecuted = transaction.DateExecuted;
            DateAccepted = transaction.DateAccepted;
            DateRejected = transaction.DateRejected;
            Anticipated = transaction.Anticipated;
            AcquirerConfirm = transaction.AcquirerConfirm;
            GrossValue = transaction.GrossValue;
            NetValue = transaction.NetValue;
            FixRate = transaction.FixRate;
            ParcelAmount = transaction.ParcelAmount;
            LastFourCardDigits = transaction.LastFourCardDigits;
            Parcels = transaction.Parcels;
        }
        public Task ExecuteResultAsync(ActionContext context)
        {
            return new JsonResult(this).ExecuteResultAsync(context);
        }
    }
}