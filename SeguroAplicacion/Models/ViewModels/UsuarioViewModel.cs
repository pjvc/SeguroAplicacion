using System.ComponentModel.DataAnnotations;

namespace SeguroAplicacion.Models.ViewModels
{
    public class UsuarioViewModel
    {
        [Required]
        [Display(Name="Cliente")]
        public string Name { get; set; }
        
        [Required]
        [Display(Name="Cedula")]
        public string Cedula { get; set; }

        [Required]
        [Display(Name = "Telefono")]
        public int Telefono { get; set; }

        [Required]
        [Display(Name = "Edad")]
        public int Edad { get; set; }
    }
}
