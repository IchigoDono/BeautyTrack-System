using System.ComponentModel.DataAnnotations;

namespace BeautyTrack_System.Models.ProcedureModels
{
    public class ProcedureViewModel
    {
        public Int32? Id { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 1)]
        public String ProcedureName { get; set; }
        [Required]
        public Decimal Price { get; set; }
    }
}
