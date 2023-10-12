using Application.Interface.Function;
using Application.Interface.Peliculas;
using Application.Interface.Salas;
using Application.Model.DTO;
using Application.Model.Response;
using Application.Validacion;

namespace TP1_ORM_Duarte_Rodrigo
{
    public class AddFuncion
    {
        private readonly IFuncionService FuncionService;
        private readonly IPeliculaService PeliculaService;
        private readonly ISalaService SalaService;

        public AddFuncion(IFuncionService FuncionService, IPeliculaService PeliculaService, ISalaService SalaService)
        {
            this.FuncionService = FuncionService;
            this.PeliculaService = PeliculaService;
            this.SalaService = SalaService;
        }

        public async void Add()
        {
            try
            {
                ImprimirPeliculas();

                Console.Write("   Seleccione el ID de una pelicula para la funcion: ");
                int PeliculaId;
                if (!int.TryParse(Console.ReadLine(), out PeliculaId))
                {
                    throw new FormatException("   Por favor ingrese un numero para la pelicula.\n");
                }

                PeliculaResponse? PeliculaResponse = await PeliculaService.GetPeliculaById(PeliculaId);
                if (PeliculaResponse == null)
                {
                    throw new FormatException("   La pelicula seleccionada no existe.\n");
                }

                ImprimirSalas();

                Console.Write("   Seleccione una sala para la funcion: ");
                int SalaId;
                if (!int.TryParse(Console.ReadLine(), out SalaId))
                {
                    throw new FormatException("   Por favor ingrese un numero para la sala.\n");
                }

                SalaResponse? SalaResponse = await SalaService.GetSalaById(SalaId);
                if (SalaResponse == null)
                {
                    throw new FormatException("   La sala seleccionada no existe.\n");
                }

                Console.Write("   Ingrese una fecha (dd-mm): ");
                DateTime Fecha = ValidarFecha.Validar(Console.ReadLine());
                Console.Write("   Ingrese un horario (hh:mm): ");
                TimeSpan Horario = ValidarHorario.Validar(Console.ReadLine());
                ValidarFechaFuncion.Validar(Fecha, Horario);

                FuncionDto FuncionDto = new FuncionDto
                {
                    PeliculaId = PeliculaId,
                    SalaId = SalaId,
                    Fecha = Fecha,
                    Horario = Horario
                };

                FuncionService.AddFuncion(FuncionDto);
                Console.Clear();
                Console.WriteLine("   Funcion programada exitosamente\n");
            }
            catch (OverflowException)
            {
                Console.Clear();
                Console.WriteLine("   Error, se han ingresado demasiados datos.\n");
            }
            catch (NullReferenceException)
            {
                Console.Clear();
                Console.WriteLine("   Ha ocurrido un error inesperado.\n");
            }
            catch (Exception Ex)
            {
                Console.Clear();
                Console.WriteLine(Ex.Message);
            }
        }

        internal async void ImprimirPeliculas()
        {
            ImprimirPeliculas ImprimirPeliculas = new ImprimirPeliculas();
            ImprimirPeliculas.Imprimir(await PeliculaService.GetAllPeliculas());
        }

        internal async void ImprimirSalas()
        {
            ImprimirSalas ImprimirSalas = new ImprimirSalas();
            ImprimirSalas.Imprimir(await SalaService.GetAllSalas());
        }
    }
}
