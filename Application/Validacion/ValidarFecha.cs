using Application.Exceptions;

namespace Application.Validacion
{
    public static class ValidarFecha
    {
        public static DateTime Validar(string Fecha)
        {
            if (Fecha.Contains("/"))
            {
                throw new ExceptionFecha("   La fecha se debe ingresar con \"-\" no con \"/\".\n");
            }
            DateTime FechaParse;
            bool Resultado = DateTime.TryParse(Fecha, out FechaParse);
            if (!Resultado)
            {
                throw new ExceptionFecha("   La fecha no se ingreso en un formato valido.\n");
            }
            else
            {
                FechaParse = FechaParse.Date;
                return FechaParse;
            }
        }
    }
}
