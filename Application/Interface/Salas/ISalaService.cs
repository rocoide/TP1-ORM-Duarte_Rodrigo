using Application.Model.Response;

namespace Application.Interface.Salas
{
    public interface ISalaService
    {
        Task<List<SalaResponse>> GetAllSalas();
        Task<SalaResponse> GetSalaById(int SalaId);
    }
}
