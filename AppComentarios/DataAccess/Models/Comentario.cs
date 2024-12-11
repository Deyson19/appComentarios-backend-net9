using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppComentarios.DataAccess.Models
{
     public class Comentario
     {
          [Key]
          public Guid Id { get; set; }
          [Required(ErrorMessage = "El campo {0} es requerido")]
          [MaxLength(50, ErrorMessage = "El campo {0} excede la cantidad máxima de letras")]

          public required string NombrePersona { get; set; }
          [Required(ErrorMessage = "El campo {0} es requerido")]
          [MaxLength(250, ErrorMessage = "El campo {0} excede la cantidad máxima de letras")]

          public required string Texto { get; set; }

          public DateTime FechaPublicacion { get; set; } = DateTime.Now;
          [ForeignKey("PublicacionId")]
          public Guid PublicacionId { get; set; }
          public Publicacion? Publicacion { get; set; }
     }
}