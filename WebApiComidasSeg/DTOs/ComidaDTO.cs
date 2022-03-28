using System.ComponentModel.DataAnnotations;
using WebApiComidasSeg.Validaciones;

namespace WebApiComidasSeg.DTOs
{
    public class ComidaDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")] //
        [StringLength(maximumLength: 150, ErrorMessage = "El campo {0} solo puede tener hasta 150 caracteres")]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }
    }
}
