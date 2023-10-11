using Application.Exceptions;

namespace Application.Validacion
{
    public static class ValidarFechaFuncion
    {
        public static void Validar(DateTime Fecha, TimeSpan Hora)
        {
            DateTime FechaActual = DateTime.Now.Date;
            DateTime FechaIngresada = Fecha.Date;
            TimeSpan HoraActual = DateTime.Now.TimeOfDay;
            if (FechaActual > FechaIngresada)
            {
                throw new ExcepcionFechaFuncion("   La funcion debe ser para una fecha posterior a la fecha actual.\n");
            }
            else
            {
                if (HoraActual > Hora)
                {
                    throw new ExcepcionFechaFuncion("   No se pueden ingresar funciones para horas previas a la hora actual en el dia de la fecha.\n");
                }
            }
        }
    }
}
