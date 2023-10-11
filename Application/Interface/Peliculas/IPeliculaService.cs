using Application.Model.Response;

namespace Application.Interface.Peliculas
{
    public interface IPeliculaService
    {
        Task<List<PeliculaResponse>> GetAllPeliculas();
        Task<PeliculaResponse?> GetPeliculaById(int PeliculaId);
    }
}
