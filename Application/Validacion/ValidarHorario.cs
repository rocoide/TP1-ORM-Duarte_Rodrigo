using Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validacion
{
    public static class ValidarHorario
    {
        public static TimeSpan Validar(string Hora)
        {
            if (Hora == "" || Hora == null) 
            {
                throw new FormatException("   Por favor ingrese un horario.\n");
            }
            TimeSpan Horario;
            bool Resultado = TimeSpan.TryParse(Hora, out Horario);
            if (!Resultado) 
            {
                throw new ExcepcionHorario("   El horario no se ingreso en un formato valido.\n");
            }
            return Horario;
        }
    }
}
