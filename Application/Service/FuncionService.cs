using Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class FuncionService : IFuncionService
    {
        private readonly IFuncionCommand FuncionCommand;
        private readonly IFuncionQuery FuncionQuery;

        public FuncionService (IFuncionCommand FuncionCommand, IFuncionQuery FuncionQuery)
        {

        }
    }
}
