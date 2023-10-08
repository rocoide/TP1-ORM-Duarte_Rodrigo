using Application.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.Peliculas
{
    public interface IPeliculaService
    {
        Task<List<PeliculaResponse>> GetAllPeliculas();
    }
}
