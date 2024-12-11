using System.ComponentModel.DataAnnotations;

namespace AppComentarios.ViewModels
{
     public class PublicacionViewModel
     {
          [Required(ErrorMessage = "El campo {0} es requerido")]
          [MaxLength(200)]
          public required string Autor { get; set; }
          [Required(ErrorMessage = "El campo {0} es requerido")]
          [MaxLength(500)]
          public required string Contenido { get; set; }
          [Required(ErrorMessage = "El campo {0} es requerido")]
          public required string Categoria { get; set; }
     }
}