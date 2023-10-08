using Application.Interface.Peliculas;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Query
{
    public class PeliculaQuery : IPeliculaQuery
    {
        private readonly CineContext Context;
        public PeliculaQuery (CineContext Context)
        {
            this.Context = Context;
        }

        public List<Pelicula> GetAllPeliculas()
        {
            List<Pelicula> peliculas = Context.Peliculas
                                              .Include(f => f.Generos)
                                              .ToList();
            return peliculas;
        }

        public async Task<Pelicula?> GetPeliculaById(int PeliculaId) 
        {
            Pelicula? Pel = Context.Peliculas
                                   .Include(f => f.Generos)
                                   .FirstOrDefault(t => t.PeliculaId == PeliculaId);
            return Pel;
        }


    }
}
