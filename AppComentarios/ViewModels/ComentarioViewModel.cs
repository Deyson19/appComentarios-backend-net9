
using System.ComponentModel.DataAnnotations;

namespace AppComentarios.ViewModels
{
     public class ComentarioViewModel
     {
          [Required(ErrorMessage = "El campo {0} es requerido")]
          [MaxLength(50, ErrorMessage = "El campo {0} excede la cantidad máxima de letras")]
          [MinLength(10, ErrorMessage = "El campo {0} debe tener al menos {1} letras.")]

          public required string NombrePersona { get; set; }
          [Required(ErrorMessage = "El campo {0} es requerido")]
          [MaxLength(250, ErrorMessage = "El campo {0} excede la cantidad máxima de letras")]
          [MinLength(10, ErrorMessage = "El campo {0} debe tener al menos {1} letras.")]

          public required string Texto { get; set; }
          public required string PublicacionId { get; set; }
     }
}