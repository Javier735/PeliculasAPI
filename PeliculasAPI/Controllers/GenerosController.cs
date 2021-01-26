using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
//using Microsoft.AspNetCore.Components;
using PeliculasAPI.Entidades;
using PeliculasAPI.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasAPI.Controllers
{
    [Route("api/generos")]
    [ApiController]
    public class GenerosController:ControllerBase
    {
        private readonly IRepositorio repositorio;
        private readonly WeatherForecastController weatherForecastController;
        private readonly ILogger<GenerosController> logger;

        public GenerosController(IRepositorio repositorio, WeatherForecastController weatherForecastController,ILogger<GenerosController> logger)
        {
            this.repositorio = repositorio;
            this.weatherForecastController = weatherForecastController;
            this.logger = logger;
        }

        [HttpGet]
        [HttpGet("listado")]
        [ResponseCache(Duration =60)]
        public ActionResult <List<Genero>> Get()
        {
            logger.LogInformation("vamos a mostrar los generos");
            return repositorio.ObtenerTodosLosGeneros();
        }


        [HttpGet("guid")]
        public ActionResult<Guid> GetGUID()
        {
            return Ok(new 
            { GUID_GenerosController=repositorio.ObtenerGUID(),
            GUID_WeatherForecastController=weatherForecastController.ObtenerGUIDWeatherForecastController()
            });
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Genero>> Get(int Id, [FromHeader] string nombre) 
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            logger.LogDebug($"Obteniendo un genero por id {Id}");
            var genero = await repositorio.ObtenerPorId(Id);

            if (genero==null)
            {
                logger.LogWarning($"no pudimos encontrar el geneo de id {Id}");
                return NotFound();
            }

            return genero;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Genero genero)
        {
            repositorio.CrearGenero(genero);
            return NoContent();
        }
        [HttpPut]
        public ActionResult Put([FromBody] Genero genero)
        {
            return NoContent();
        }
        [HttpDelete]
        public ActionResult Delete()
        {
            return NoContent();
        }


        //-----
    }
}
