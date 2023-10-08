using Application.Model.Response;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.Function
{
    public interface IFuncionQuery
    {
        Task<List<Funcion>> ListarTitu(string titu);
        Task<List<Funcion>> ListarFecha(DateTime Fecha);
        Task<List<Funcion>> ListarTituFecha(string Titu, DateTime Fecha);
    }
}
