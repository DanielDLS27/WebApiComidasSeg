using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiComidasSeg.DTOs;
using WebApiComidasSeg.Entidades;
using WebApiComidasSeg.Services;

namespace WebApiComidasSeg.Controllers
{
    [ApiController]
    [Route("comidas")]
    public class ComidasController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public ComidasController(ApplicationDbContext context, IMapper mapper)
        {
            this.dbContext = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetComidaDTO>>> Get()
        {
            var comidas = await dbContext.Comidas.ToListAsync();
            return mapper.Map<List<GetComidaDTO>>(comidas);
        }


        [HttpGet("{id:int}")] //Se puede usar ? para que no sea obligatorio el parametro /{param=Gustavo}  getAlumno/{id:int}/
        public async Task<ActionResult<GetComidaDTO>> Get(int id)
        {
            var comida = await dbContext.Comidas.FirstOrDefaultAsync(comidaBD => comidaBD.Id == id);

            if (comida == null)
            {
                return NotFound();
            }

            return mapper.Map<GetComidaDTO>(comida);

        }

        [HttpGet("{nombre}")]
        public async Task<ActionResult<List<GetComidaDTO>>> Get([FromRoute] string nombre)
        {
            var comidas = await dbContext.Comidas.Where(comidaBD => comidaBD.Nombre.Contains(nombre)).ToListAsync();

            EscribirArchivoGet EscribirGet = new EscribirArchivoGet();
            foreach(var comida in comidas)
            {
                EscribirGet.DoWork(comida.Nombre);
            }

            return mapper.Map<List<GetComidaDTO>>(comidas);

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ComidaDTO comidaDto)
        {

            var existeComidaMismoNombre = await dbContext.Comidas.AnyAsync(x => x.Nombre == comidaDto.Nombre);

            if (existeComidaMismoNombre)
            {
                return BadRequest($"Ya existe una comida con el nombre {comidaDto.Nombre}");
            }

            var comida = mapper.Map<Comida>(comidaDto);

            dbContext.Add(comida);
            await dbContext.SaveChangesAsync();

            EscribirArchivoPost EscribirPost = new EscribirArchivoPost();
            EscribirPost.DoWork(comidaDto.Nombre);

            return Ok();
        }

        [HttpPut("{id:int}")] // api/alumnos/1
        public async Task<ActionResult> Put(Comida comida, int id)
        {
            var exist = await dbContext.Comidas.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound();
            }

            if (comida.Id != id)
            {
                return BadRequest("El id de la comida no coincide con el establecido en la url.");
            }

            dbContext.Update(comida);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Comidas.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound("El Recurso no fue encontrado.");
            }

            dbContext.Remove(new Comida()
            {
                Id = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
