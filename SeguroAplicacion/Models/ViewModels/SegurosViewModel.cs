using System.ComponentModel.DataAnnotations;
namespace SeguroAplicacion.Models.ViewModels
{
    public class SegurosViewModel
    {
        [Required]
        [Display(Name="NombreSeguro")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "CodigoSeguro")]
        public string CodigoSeguro { get; set; }

        [Required]
        [Display(Name = "SumaAsegurada")]
        public int SumaAsegurada { get; set; }

        [Required]
        [Display(Name = "Prima")]
        public int Prima { get; set; }

    }
}
