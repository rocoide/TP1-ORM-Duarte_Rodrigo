using Application.Interface.Function;
using Domain.Entity;
using Infrastructure.Persistence;

namespace Infrastructure.Command
{
    public class FuncionCommand : IFuncionCommand
    {
        private readonly CineContext Context;

        public FuncionCommand(CineContext Context)
        {
            this.Context = Context;
        }

        public void AddFuncion(Funcion Funcion)
        {
            Context.Funciones.Add(Funcion);
            Context.SaveChanges();
        }
    }
}
