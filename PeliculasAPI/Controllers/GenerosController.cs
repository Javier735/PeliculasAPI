using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
//using Microsoft.AspNetCore.Components;
using PeliculasAPI.Entidades;
using PeliculasAPI.Filtros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasAPI.Controllers
{
    [Route("api/generos")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GenerosController:ControllerBase
    {       
        
        private readonly ILogger<GenerosController> logger;
        private readonly AplicationDbContext context;

        public GenerosController(ILogger<GenerosController> logger,
            AplicationDbContext context)
        {
           
            this.logger = logger;
            this.context = context;
        }

        [HttpGet]       
        public async Task<ActionResult <List<Genero>>> Get()
        {
            return await context.Generos.ToListAsync();
        }
       
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Genero>> Get(int Id) 
        {

            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Genero genero)
        {
            context.Add(genero);
            await context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut]
        public ActionResult Put([FromBody] Genero genero)
        {
            throw new NotImplementedException();
        }
        [HttpDelete]
        public ActionResult Delete()
        {
            throw new NotImplementedException();
        }


        //-----
    }
}
