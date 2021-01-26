using PeliculasAPI.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasAPI.Repositorios
{
    public interface IRepositorio
    {
        Genero ObtenerPorId(int Id);
        List<Genero> ObtenerTodosLosGeneros();
    }
}
