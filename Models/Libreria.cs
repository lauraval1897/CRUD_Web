using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRUD_Libreria.Models
{
    public partial class Libreria
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="NOMBRE DE LIBRO REQUERIDO")]
        [Display(Name = "Nombre del libro")]
        public string NombreLibro { get; set; }
        [Required(ErrorMessage = "NOMBRE DEL AUTOR REQUERIDO")]
        [Display(Name = "Nombre del autor")]
        public string Autor { get; set; }
        [Required(ErrorMessage = "AÑO DE PUBLICACION REQUERIDO")]
        [Display(Name = "AÑO DE PUBLICACION")]
        public int AñoPublicacion { get; set; }
        [Required(ErrorMessage = "CANTIDAD DE LIBROS REQUERIDO")]
        [Display(Name = "CANTIDAD DE LIBROS")]
        public int Cantidad { get; set; }
    }
}
