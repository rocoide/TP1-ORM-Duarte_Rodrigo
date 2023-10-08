using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.Response
{
    public class FuncionResponse
    {
        public string PeliculaNombre { get; set; }
        public string SalaNombre { get; set; }
        public string Genero { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Horario { get; set; }
    }
}
