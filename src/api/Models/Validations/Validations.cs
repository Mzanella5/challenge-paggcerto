
using System.ComponentModel.DataAnnotations;

namespace challengePaggcerto.src.api.Models.Validations
{
    public class JsonFirstFourDigits : RangeAttribute
    {
        private const Double Min = 5999;
        private const Double Max = 5999;
        public JsonFirstFourDigits() : base(Min, Max)
        {
            ErrorMessage = $"The first four numbers of credit card cant be {Min}";
        }

    }
    public class JsonCurrency : RangeAttribute
    {
        private const Double Min = 0;
        private const Double Max = 999999999.99;

        public JsonCurrency() : base(Min, Max)
        {
            ErrorMessage = $"Between {Minimum} and {Maximum}.";
        }
    }

}