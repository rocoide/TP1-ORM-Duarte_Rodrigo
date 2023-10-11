using Domain.Entity;

namespace Application.Interface.Function
{
    public interface IFuncionQuery
    {
        Task<List<Funcion>> ListarTitu(string titu);
        Task<List<Funcion>> ListarFecha(DateTime Fecha);
        Task<List<Funcion>> ListarTituFecha(string Titu, DateTime Fecha);
    }
}
