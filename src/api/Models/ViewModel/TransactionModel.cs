using System.ComponentModel.DataAnnotations;
using challengePaggcerto.src.api.Models.EntityModel;
using Newtonsoft.Json;
using challengePaggcerto.src.api.Models.Validations;

namespace challengePaggcerto.src.api.Models.ViewModel
{
    public class TransactionModel
    {

        [Display(Name = "id")]
        public long Id { get; set; }

        [Display(Name = "dateExecuted"), JsonRequired]
        public DateTime DateExecuted { get; set; }

        [Display(Name = "acquirerConfirm"), JsonRequired]
        public bool AcquirerConfirm { get; set; }

        [Display(Name = "grossValue"), JsonRequired, JsonCurrency]
        public double GrossValue { get; set; }

        [Display(Name = "fixRate"), JsonRequired]
        public double FixRate { get; set; }

        [Display(Name = "parcelAmount"), JsonRequired]
        public int ParcelAmount { get; set; }

        [Display(Name = "lastFourCardDigits"), JsonRequired]
        public string? LastFourCardDigits { get; set; }

        [Display(Name = "creditCard")]
        public CreditCardModel? CreditCard { get; set; }

        public Transaction Map()
        {
            return new Transaction{
                Id = this.Id,
                DateExecuted = this.DateExecuted,
                AcquirerConfirm = this.AcquirerConfirm,
                GrossValue = this.GrossValue,
                FixRate = this.FixRate,
                ParcelAmount = this.ParcelAmount,
                LastFourCardDigits = this.LastFourCardDigits               
            };
        }

    }
}