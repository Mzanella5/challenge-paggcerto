using System.ComponentModel.DataAnnotations;
using challengePaggcerto.src.api.Models.EntityModel;
using Newtonsoft.Json;

namespace challengePaggcerto.src.api.Models.ViewModel
{
    public class ListIdsModel
    {
        public List<long> ?Ids {get; set;}
    }
}