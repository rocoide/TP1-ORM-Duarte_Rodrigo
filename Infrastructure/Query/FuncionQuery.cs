using Application.Interface.Function;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query
{
    public class FuncionQuery : IFuncionQuery
    {
        private readonly CineContext Context;

        public FuncionQuery(CineContext Context)
        {
            this.Context = Context;
        }

        public async Task<List<Funcion>> ListarTitu(string Titu)
        {
            List<Funcion> lista = Context.Funciones
                                         .Include(f => f.Peliculas)
                                             .ThenInclude(p => p.Generos)
                                         .Include(f => f.Salas)
                                         .Where(f => f.Peliculas.Titulo.Contains(Titu))
                                         .ToList();
            return lista;
        }

        public async Task<List<Funcion>> ListarFecha(DateTime Fecha)
        {
            List<Funcion> lista = Context.Funciones
                                            .Include(f => f.Peliculas)
                                                .ThenInclude(p => p.Generos)
                                            .Include(f => f.Salas)
                                            .Where(f => f.Fecha.Day == Fecha.Day && (f.Fecha.Month == Fecha.Month))
                                            .ToList();
            return lista;
        }

        public async Task<List<Funcion>> ListarTituFecha(string Titu, DateTime Fecha)
        {
            List<Funcion> lista = Context.Funciones
                                            .Include(f => f.Peliculas)
                                                .ThenInclude(p => p.Generos)
                                            .Include(f => f.Salas)
                                            .Where(f => f.Peliculas.Titulo.Contains(Titu) && f.Fecha.Day == Fecha.Day && (f.Fecha.Month == Fecha.Month))
                                            .ToList();
            return lista;
        }

    }
}
