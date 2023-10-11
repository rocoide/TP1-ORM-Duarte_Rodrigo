using Application.Interface.Salas;
using Domain.Entity;

namespace Infrastructure.Query
{
    public class SalaQuery : ISalaQuery
    {
        private readonly CineContext Context;

        public SalaQuery(CineContext Context)
        {
            this.Context = Context;
        }

        public async Task<List<Sala>> GetAllSalas()
        {
            List<Sala> ListaSala = Context.Salas.ToList();
            return ListaSala;
        }

        public async Task<Sala?> GetSalaById(int SalaId)
        {
            Sala? Sala = Context.Salas.FirstOrDefault(f => f.SalaId == SalaId);
            return Sala;
        }
    }
}
