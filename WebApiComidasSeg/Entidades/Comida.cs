﻿using System.ComponentModel.DataAnnotations;
using WebApiComidasSeg.Validaciones;

namespace WebApiComidasSeg.Entidades
{
    public class Comida
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")] //
        [StringLength(maximumLength: 150, ErrorMessage = "El campo {0} solo puede tener hasta 150 caracteres")]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }

    }
}
