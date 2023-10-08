using Application.Interface.Function;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Command
{
    public class FuncionCommand : IFuncionCommand
    {
        private readonly CineContext Context;

        public FuncionCommand(CineContext Context) 
        {
            this.Context = Context;
        }
    }
}
