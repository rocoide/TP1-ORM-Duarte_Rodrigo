using Application.Interface.Peliculas;
using Application.Model.Response;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            List<Pelicula> ListaPeliculas = await PeliculaQuery.GetAllPeliculas();
            List<PeliculaResponse> ListaResponse = new List<PeliculaResponse>();
            PeliculaResponse PelResponse;
            foreach(Pelicula Pel in ListaPeliculas)
            {
                PelResponse = new PeliculaResponse
                {
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
    }
}
