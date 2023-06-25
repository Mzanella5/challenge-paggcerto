using System.ComponentModel.DataAnnotations;
using challengePaggcerto.src.api.Models.EntityModel;
using Newtonsoft.Json;

namespace challengePaggcerto.src.api.Models.ViewModel
{
    public class ListAnticipationModel
    {
        [Display(Name = "AnticipationModels"), JsonRequired, MinLength(1)]
        public ICollection<AnticipationModel>? AnticipationModels {get; set;}
        public List<Anticipation> Map()
        {
            return this.AnticipationModels!.Select(t => t.Map()).ToList();
        }
    
    }
}