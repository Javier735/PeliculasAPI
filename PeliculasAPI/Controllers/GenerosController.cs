using Microsoft.AspNetCore.Mvc;
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
    public class GenerosController:ControllerBase
    {
        private readonly IRepositorio repositorio;

        public GenerosController(IRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet]
        public List<Genero> Get()
        {
            return repositorio.ObtenerTodosLosGeneros();
        }
        [HttpGet("{id}")]
        public Genero Get(int Id)
        {
            var genero = repositorio.ObtenerPorId(Id);

            if (genero==null)
            {
                //return NotFound();
            }


            return genero;
        }

        [HttpPost]
        public void Post()
        {

        }
        [HttpPut]
        public void Put(){
        
        }
        [HttpDelete]
        public void Delete()
        {

        }


        //-----
    }
}
