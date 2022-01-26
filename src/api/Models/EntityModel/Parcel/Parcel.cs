
namespace challengePaggcerto.src.api.Models.EntityModel
{
    public class Parcel
    {
        public long Id { get; set; }
        public Transaction? Transaction { get; set; }
        public double GrossValue { get; set; }
        public double NetValue { get; set; }
        public int ParcelNumber { get; set; }
        public double ValueAnticipated { get; set; }
        public DateTime DateReceived { get; set; }
        public DateTime? DatePassedOn { get; set; }


    }

}