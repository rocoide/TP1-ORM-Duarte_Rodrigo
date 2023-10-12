using Application.Interface.Function;
using Application.Interface.Peliculas;
using Application.Interface.Salas;
using Application.Model.Response;
using Application.Service;
using Application.Validacion;
using Infrastructure.Persistence;
using Infrastructure.Command;
using Infrastructure.Query;
using TP1_ORM_Duarte_Rodrigo;

namespace EF6Console
{
    class Program
    {
        static void Main(string[] args)
        {
            bool Menu = true;
            while (Menu)
            {
                try
                {
                    using (var Ctx = new CineContext())
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("                                     Bienvenidos al cine\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("   Por favor elija una opcion");
                        Console.WriteLine("      1 - Listar funciones");
                        Console.WriteLine("      2 - Registrar funcion");
                        Console.WriteLine("      3 - Salir\n");
                        Console.Write("   Ingrese una opcion: ");
                        int Opcion;
                        if (!int.TryParse(Console.ReadLine(), out Opcion))
                        {
                            throw new FormatException("   Por favor ingrese un numero.\n");
                        }
                        Console.WriteLine("");

                        IFuncionQuery FuncionQuery = new FuncionQuery(Ctx);
                        IFuncionCommand FuncionCommand = new FuncionCommand(Ctx);
                        IFuncionService FuncionService = new FuncionService(FuncionCommand, FuncionQuery);

                        IPeliculaQuery PeliculaQuery = new PeliculaQuery(Ctx);
                        IPeliculaService PeliculaService = new PeliculaService(PeliculaQuery);

                        ISalaQuery SalaQuery = new SalaQuery(Ctx);
                        ISalaService SalaService = new SalaService(SalaQuery);

                        switch (Opcion)
                        {
                            case 1:
                                ListarFunciones(FuncionService);
                                break;
                            case 2:
                                AddFuncion AddFuncion = new AddFuncion(FuncionService, PeliculaService, SalaService);
                                AddFuncion.Add();
                                break;
                            case 3:
                                Menu = false;
                                break;
                            default:
                                Console.WriteLine("   No se ha ingresado una opcion valida.\n");
                                break;
                        }
                    }
                }
                catch (NullReferenceException)
                {
                    Console.Clear();
                    Console.WriteLine("   Se ha producido en un error inesperado.\n");
                }
                catch (OverflowException)
                {
                    Console.Clear();
                    Console.WriteLine("   Se han ingresado demasiados datos, error.\n");
                }
                catch (Exception Ex)
                {
                    Console.Clear();
                    Console.WriteLine(Ex.Message);
                }
            }
            Console.WriteLine("   Gracias por utilizar nuestros servicios. Que tenga un buen dia :)");
        }



        static async void ListarFunciones(IFuncionService FuncionService)
        {
            bool Menu = true;
            ImprimirFunciones ImprimirFunciones = new ImprimirFunciones();
            while (Menu)
            {
                try
                {
                    Console.WriteLine("   Opciones de listado:");
                    Console.WriteLine("      1 - Listar por titulo");
                    Console.WriteLine("      2 - Listar por fecha");
                    Console.WriteLine("      3 - Listar por titulo y dia");
                    Console.WriteLine("      4 - volver al menu\n");
                    Console.Write("   Ingrese una opcion: ");
                    int Opcion;
                    if (!int.TryParse(Console.ReadLine(), out Opcion))
                    {
                        throw new FormatException("   Por favor ingrese un numero.\n");
                    }
                    switch (Opcion)
                    {
                        case 1:
                            Console.Write("   Ingrese el titulo que desea listar: ");
                            string Titu = Console.ReadLine();
                            Console.WriteLine("");
                            if (Titu != null && Titu != "")
                            {
                                List<FuncionResponse> ListaFuncionResponse = await FuncionService.ListarTitu(Titu);
                                ImprimirFunciones.Imprimir(ListaFuncionResponse);
                            }
                            else
                            {
                                throw new FormatException("   Por favor ingrese un titulo.\n");
                            }
                            break;
                        case 2:
                            Console.Write("   Ingrese el la fecha que desea listar (dd-mm): ");
                            DateTime FechaValidada = ValidarFecha.Validar(Console.ReadLine()); //Valida la fecha y devuelve un DateTime, de no ser validada lanza excepcion con msg
                            Console.WriteLine("");
                            List<FuncionResponse> ListaFuncionResponse2 = await FuncionService.ListarFecha(FechaValidada);
                            ImprimirFunciones.Imprimir(ListaFuncionResponse2);
                            break;
                        case 3:
                            Console.Write("   Ingrese el titulo que desea listar: ");
                            string Titu2 = Console.ReadLine();
                            if (Titu2 != null && Titu2 != "")
                            {
                                Console.Write("   Ingrese el la fecha que desea listar (dd-mm): ");
                                DateTime FechaValidada2 = ValidarFecha.Validar(Console.ReadLine());
                                Console.WriteLine("");
                                List<FuncionResponse> ListaFuncionResponse3 = await FuncionService.ListarTituFecha(Titu2, FechaValidada2);
                                ImprimirFunciones.Imprimir(ListaFuncionResponse3);
                            }
                            else
                            {
                                throw new FormatException("   Por favor ingrese un titulo.\n");
                            }
                            break;
                        case 4:
                            Menu = false;
                            Console.Clear();
                            break;              //no hace nada y vuelve al menu
                        default:
                            Console.WriteLine("   No se ha ingresado una opcion valida.\n");
                            break;
                    }
                }
                catch (OverflowException)
                {
                    Console.Clear();
                    Console.WriteLine("   Se han ingresado demasiados datos, error.\n   ");
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
        }

    }
}