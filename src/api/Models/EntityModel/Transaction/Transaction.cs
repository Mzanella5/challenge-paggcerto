
namespace challengePaggcerto.src.api.Models.EntityModel
{
    public class Transaction
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
        public Anticipation? Anticipation { get; set; }

    }

}