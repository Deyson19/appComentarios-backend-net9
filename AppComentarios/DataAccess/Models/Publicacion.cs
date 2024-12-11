using System.ComponentModel.DataAnnotations;

namespace AppComentarios.DataAccess.Models
{
     public class Publicacion
     {
          [Key]
          public Guid Id { get; set; }
          [Required(ErrorMessage = "El campo {0} es requerido")]
          [MaxLength(200)]
          public required string Autor { get; set; }
          [Required(ErrorMessage = "El campo {0} es requerido")]
          [MaxLength(500)]
          public required string Contenido { get; set; }
          [Required(ErrorMessage = "El campo {0} es requerido")]
          public required string Categoria { get; set; }

          public DateTime FechaPublicacion { get; set; } = DateTime.Now;

          //*Relación entre Una publicación y muchos comentarios
          public virtual required ICollection<Comentario> Comentarios { get; set; }
     }
}
