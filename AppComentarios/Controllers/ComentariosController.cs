using AppComentarios.DataAccess;
using AppComentarios.DataAccess.Models;
using AppComentarios.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppComentarios.Controllers
{
     [ApiController]
     [Route("api/[controller]")]
     public class ComentariosController(ComentariosDbContext dbContext) : ControllerBase
     {
          private readonly ComentariosDbContext _dbContext = dbContext;

          [HttpGet]
          public async Task<IActionResult> Get()
          {
               var comentarios = await _dbContext.Comentarios.ToListAsync();
               return Ok(comentarios);
          }
          [HttpGet("{id}")]
          public async Task<IActionResult> Get(Guid id)
          {
               var comentario = await _dbContext.Comentarios.Include(p=>p.Publicacion).SingleOrDefaultAsync(x=>x.Id ==id);
               return comentario != null ? Ok(comentario) : NotFound();
          }

          [HttpPost]
          public async Task<IActionResult> Post([FromBody] ComentarioViewModel model)
          {
               if (!ModelState.IsValid)
               {
                    return BadRequest(new
                    {
                         message = "No se pudo crear el comentario"
                    });
               }
               //*Volví al mute => tranquilos
               Comentario entidad = new()
               {
                    NombrePersona = model.NombrePersona,
                    Texto = model.Texto,
                    PublicacionId = Guid.Parse(model.PublicacionId),
               };
               await _dbContext.Comentarios.AddAsync(entidad);
               await _dbContext.SaveChangesAsync();

               return Ok(new
               {
                    message = "Comentario agregado"
               });
          }
     }
}