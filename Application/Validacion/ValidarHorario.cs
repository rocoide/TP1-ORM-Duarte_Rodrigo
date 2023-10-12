using Application.Exceptions;

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
            if (!TimeSpan.TryParse(Hora, out Horario))
            {
                throw new ExcepcionHorario("   El horario no se ingreso en un formato valido.\n");
            }
            return Horario;
        }
    }
}
