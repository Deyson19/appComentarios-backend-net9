using AppComentarios.DataAccess;
using AppComentarios.DataAccess.Models;
using AppComentarios.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppComentarios.Controllers
{
     [ApiController]
     [Route("api/[controller]")]
     public class PublicacionesController(ComentariosDbContext dbContext) : ControllerBase
     {
          private readonly ComentariosDbContext _dbContext = dbContext;

          [HttpGet]
          public async Task<IActionResult> Get()
          {
               var listado = await _dbContext.Publicaciones.ToListAsync();
               return Ok(listado);
          }
          [HttpGet("{id}")]
          public async Task<IActionResult> Get(Guid id)
          {
               //*Guid nunca es null
               var publicacion = await _dbContext.Publicaciones.Include(c => c.Comentarios).FirstOrDefaultAsync(x => x.Id == id);
               if (publicacion != null)
               {
                    return Ok(publicacion);
               }
               else
               {
                    return NotFound(new { message = "No hay coincidencias" });
               }

          }
          [HttpPost]
          public async Task<IActionResult> Post(PublicacionViewModel model)
          {
               if (ModelState.IsValid)
               {
                    var entidad = new Publicacion
                    {
                         Autor = model.Autor,
                         Contenido = model.Contenido,
                         Categoria = model.Categoria
                    };
                    await _dbContext.Publicaciones.AddAsync(entidad);
                    await _dbContext.SaveChangesAsync();
                    return Ok(new
                    {
                         message = "Publicación creada"
                    });
               }
               return BadRequest(new
               {
                    message = "Los datos no son correctos"
               });
          }
          [HttpPost("AddRange")]
          public async Task<IActionResult> Post(List<PublicacionViewModel> models)
          {

               if (ModelState.IsValid)
               {
                    foreach (var model in models)
                    {
                         var entidad = new Publicacion
                         {
                              Autor = model.Autor,
                              Contenido = model.Contenido,
                              Categoria = model.Categoria
                         };
                         await _dbContext.Publicaciones.AddAsync(entidad);
                    }
                    await _dbContext.SaveChangesAsync();
                    return Ok(new
                    {
                         message = "Publicaciones creadas"
                    });
               }
               return BadRequest(new
               {
                    message = "Los datos no son correctos"
               });
          }

     }
}