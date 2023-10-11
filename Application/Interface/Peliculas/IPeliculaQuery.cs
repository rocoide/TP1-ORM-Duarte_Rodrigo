using Domain.Entity;

namespace Application.Interface.Peliculas
{
    public interface IPeliculaQuery
    {
        List<Pelicula> GetAllPeliculas();
        Task<Pelicula?> GetPeliculaById(int PeliculaId);
    }
}
