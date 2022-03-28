using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiComidasSeg.Entidades;

namespace WebApiComidasSeg.Controllers
{
    [ApiController]
    [Route("restaurantes")]
    public class RestaurantesController : ControllerBase
    {

        private readonly ApplicationDbContext dbContext;

        public RestaurantesController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        [HttpGet]
        [HttpGet("/listadoRestaurante")]
        public async Task<ActionResult<List<Restaurante>>> GetAll()
        {
            return await dbContext.Restaurantes.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Restaurante>> GetById(int id)
        {
            return await dbContext.Restaurantes.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Restaurante restaurante)
        {
            //var existeAlumno = await dbContext.Alumnos.AnyAsync(x => x.Id == clase.AlumnoId);

            //if (!existeAlumno)
            //{
            //    return BadRequest($"No existe el alumno con el id: {clase.AlumnoId} ");
            //}

            dbContext.Add(restaurante);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Restaurante restaurante, int id)
        {
            var exist = await dbContext.Restaurantes.AnyAsync(x => x.Id == id);

            if (!exist)
            {
                return NotFound("El restaurante especificado no existe. ");
            }

            if (restaurante.Id != id)
            {
                return BadRequest("El id del restaurante no coincide con el establecido en la url. ");
            }

            dbContext.Update(restaurante);
            await dbContext.SaveChangesAsync();
            return Ok();

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Restaurantes.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound("El Recurso no fue encontrado.");
            }

            //var validateRelation = await dbContext.AlumnoClase.AnyAsync


            dbContext.Remove(new Restaurante { Id = id });
            await dbContext.SaveChangesAsync();
            return Ok();
        }

    }
}
