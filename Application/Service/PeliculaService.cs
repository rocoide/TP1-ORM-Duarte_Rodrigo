using Application.Interface.Peliculas;
using Application.Model.Response;
using Domain.Entity;

namespace Application.Service
{
    public class PeliculaService : IPeliculaService
    {
        private readonly IPeliculaQuery PeliculaQuery;
        public PeliculaService(IPeliculaQuery PeliculaQuery)
        {
            this.PeliculaQuery = PeliculaQuery;
        }

        public async Task<List<PeliculaResponse>> GetAllPeliculas()
        {
            List<Pelicula> ListaPeliculas = PeliculaQuery.GetAllPeliculas();
            List<PeliculaResponse> ListaResponse = new List<PeliculaResponse>();
            PeliculaResponse PelResponse;
            foreach (Pelicula Pel in ListaPeliculas)
            {
                PelResponse = new PeliculaResponse
                {
                    PeliculaId = Pel.PeliculaId,
                    Titulo = Pel.Titulo,
                    Sinopsis = Pel.Sinopsis,
                    Poster = Pel.Poster,
                    Trailer = Pel.Trailer,
                    Genero = Pel.Generos.Nombre
                };
                ListaResponse.Add(PelResponse);
            }
            return ListaResponse;
        }


        public async Task<PeliculaResponse?> GetPeliculaById(int PeliculaId)
        {
            Pelicula? Pel = await PeliculaQuery.GetPeliculaById(PeliculaId);
            if (Pel != null)
            {
                PeliculaResponse PelResponse = new PeliculaResponse
                {
                    PeliculaId = Pel.PeliculaId,
                    Titulo = Pel.Titulo,
                    Sinopsis = Pel.Sinopsis,
                    Poster = Pel.Poster,
                    Trailer = Pel.Trailer,
                    Genero = Pel.Generos.Nombre
                };
                return PelResponse;
            }
            return null;
        }



    }
}
