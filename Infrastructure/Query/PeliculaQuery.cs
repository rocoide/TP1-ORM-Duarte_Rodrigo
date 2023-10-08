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

        public async Task<List<Pelicula>> GetAllPeliculas()
        {
            List<Pelicula> peliculas = await Context.Peliculas
                                                    .Include(f => f.Generos)
                                                    .ToListAsync();
            return peliculas;
        }
    }
}
