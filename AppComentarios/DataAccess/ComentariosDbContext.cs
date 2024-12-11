using AppComentarios.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace AppComentarios.DataAccess
{
     public class ComentariosDbContext : DbContext
     {
          public ComentariosDbContext(DbContextOptions<ComentariosDbContext> op) : base(op)
          {

          }

          public required DbSet<Comentario> Comentarios { get; set; }
          public required DbSet<Publicacion> Publicaciones { get; set; }
     }
}