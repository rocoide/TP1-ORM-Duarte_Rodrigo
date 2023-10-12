using Application.Interface.Peliculas;
using Domain.Entity;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query
{
    public class PeliculaQuery : IPeliculaQuery
    {
        private readonly CineContext Context;
        public PeliculaQuery(CineContext Context)
        {
            this.Context = Context;
        }

        public List<Pelicula> GetAllPeliculas()
        {
            List<Pelicula> Peliculas = Context.Peliculas
                                              .Include(f => f.Generos)
                                              .ToList();
            return Peliculas;
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
