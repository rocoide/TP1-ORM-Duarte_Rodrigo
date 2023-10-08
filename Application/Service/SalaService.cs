using Application.Interface.Salas;
using Application.Model.Response;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class SalaService : ISalaService
    {
        private readonly ISalaQuery SalaQuery;
        public SalaService(ISalaQuery SalaQuery) 
        {
            this.SalaQuery = SalaQuery;
        }

        public async Task<List<SalaResponse>> GetAllSalas() 
        {
            List<Sala> ListaSalas = await SalaQuery.GetAllSalas();
            List<SalaResponse> ListaResponse = new List<SalaResponse>();
            SalaResponse SalaResponse;
            foreach(Sala Sala in ListaSalas) 
            {
                SalaResponse = new SalaResponse
                {
                    SalaId = Sala.SalaId,
                    Nombre = Sala.Nombre,
                    Capacidad = Sala.Capacidad
                };
                ListaResponse.Add(SalaResponse);
            }
            return ListaResponse;
        }

        public async Task<SalaResponse?> GetSalaById(int SalaId) 
        {
            Sala? Sala = await SalaQuery.GetSalaById(SalaId);
            if (Sala != null)
            {
                SalaResponse SalaResponse = new SalaResponse
                {
                    SalaId = Sala.SalaId,
                    Nombre = Sala.Nombre,
                    Capacidad = Sala.Capacidad
                };
                return SalaResponse;
            }
            return null;
        }
    }
}
