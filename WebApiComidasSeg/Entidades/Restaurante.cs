using System.ComponentModel.DataAnnotations;
using WebApiComidasSeg.Validaciones;

namespace WebApiComidasSeg.Entidades
{
    public class Restaurante
    {

        public int Id { get; set; }
        [StringLength(maximumLength: 250, ErrorMessage = "El campo {0} solo puede tener hasta 250 caracteres")]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }

    }
}
