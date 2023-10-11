using Domain.Entity;

namespace Application.Interface.Salas
{
    public interface ISalaQuery
    {
        Task<List<Sala>> GetAllSalas();
        Task<Sala?> GetSalaById(int SalaId);
    }
}
