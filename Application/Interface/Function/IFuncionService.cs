using Application.Model.DTO;
using Application.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.Function
{
    public interface IFuncionService
    {
        Task<List<FuncionResponse>> ListarTitu(string Titu);
        Task<List<FuncionResponse>> ListarFecha(DateTime Fech);
        Task<List<FuncionResponse>> ListarTituFecha(string Titu, DateTime Fech);
        void AddFuncion(FuncionDto FuncionDto);
    }
}
