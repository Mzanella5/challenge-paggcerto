using System.ComponentModel.DataAnnotations;
using challengePaggcerto.src.api.Models.EntityModel;
using Newtonsoft.Json;
using challengePaggcerto.src.api.Models.Validations;

namespace challengePaggcerto.src.api.Models.ViewModel
{
    public class CreditCardModel
    {
        [Display(Name = "cardNumber"), JsonRequired, MaxLength(16), MinLength(16)]
        public String? CardNumber { get; set; }

        [Display(Name = "validity"), JsonRequired]
        public DateTime? Validity { get; set; }

        [Display(Name = "securityCode"), JsonRequired]
        public String? SecurityCode { get; set; }

        public CreditCardModel Map()
        {
            return new CreditCardModel{
                CardNumber = this.CardNumber,
                Validity = this.Validity,
                SecurityCode = this.SecurityCode
            };
        }

    }
}