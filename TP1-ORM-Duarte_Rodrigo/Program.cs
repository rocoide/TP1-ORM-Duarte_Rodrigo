using Application.Exceptions;
using Application.Interface;
using Application.Interface.Function;
using Application.Interface.Peliculas;
using Application.Interface.Salas;
using Application.Model.Response;
using Application.Service;
using Application.Validacion;
using Domain.Entity;
using Infrastructure;
using Infrastructure.Command;
using Infrastructure.Query;
using System.Collections.Generic;
using TP1_ORM_Duarte_Rodrigo;

namespace EF6Console
{
    class Program
    {
        static void Main(string[] args)
        {
            bool menu = true;
            while (menu)
            {
                try
                {
                    using (var Ctx = new CineContext())
                    {   
                        Console.WriteLine("   Bienvenidos al cine\n");
                        Console.WriteLine("   Por favor elija una opcion");
                        Console.WriteLine("   1 - Listar funciones");
                        Console.WriteLine("   2 - Registrar funcion");
                        Console.WriteLine("   3 - Salir\n");
                        Console.Write("   Ingrese una opcion: ");
                        int opcion = int.Parse(Console.ReadLine());
                        Console.WriteLine("");

                        IFuncionQuery FuncionQuery = new FuncionQuery(Ctx);
                        IFuncionCommand FuncionCommand = new FuncionCommand(Ctx);
                        IFuncionService FuncionService = new FuncionService(FuncionCommand, FuncionQuery);

                        IPeliculaQuery PeliculaQuery = new PeliculaQuery(Ctx);
                        IPeliculaService PeliculaService = new PeliculaService(PeliculaQuery);

                        ISalaQuery SalaQuery = new SalaQuery(Ctx);
                        ISalaService SalaService = new SalaService(SalaQuery);

                        switch (opcion)
                        {
                            case 1:
                                ListarFunciones(FuncionService);
                                break;
                            case 2:
                                ListarPeliculas(PeliculaService);
                                AddFuncion AniadirFuncion = new AddFuncion(FuncionService, PeliculaService, SalaService);
                                AniadirFuncion.Add();
                                break;
                            case 3:
                                menu = false;
                                break;
                            default:
                                Console.WriteLine("   No se ha ingresado una opcion valida.\n");
                                break;
                        }
                    }
                }
                catch (OverflowException)
                {
                    Console.Clear();
                    Console.WriteLine("   Se han ingresado demasiados datos, error.\n");
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("   Por favor ingrese una opcion valida.\n");
                }
                catch (Exception Ex)
                {
                    Console.Clear();
                    Console.WriteLine("   Ha ocurrido un error inesperado.\n" + Ex.Message);
                }
            }
            Console.WriteLine("   Gracias por utilizar nuestros servicios. Que tenga un buen dia :)");
        }



        static async void ListarFunciones(IFuncionService FuncionService)
        {
            bool menu = true;
            ImprimirFunciones ImprimirFunciones = new ImprimirFunciones();
            while (menu)
            {
                try
                {
                    Console.WriteLine("   opciones de listado:\n");
                    Console.WriteLine("   1 - Listar por titulo");
                    Console.WriteLine("   2 - Listar por dia");
                    Console.WriteLine("   3 - Listar por titulo y dia");
                    Console.WriteLine("   4 - volver al menu\n");
                    Console.Write("   Ingrese una opcion: ");
                    int opcion2 = int.Parse(Console.ReadLine());
                    switch (opcion2)
                    {
                        case 1:
                            Console.Write("   Ingrese el titulo que desea listar: ");
                            string Titu = Console.ReadLine();
                            Console.WriteLine("");
                            if (Titu != "")
                            {
                                List<FuncionResponse> ListaFuncionResponse = await FuncionService.ListarTitu(Titu);
                                ImprimirFunciones.Imprimir(ListaFuncionResponse);
                            }
                            else
                            {
                                Console.WriteLine("   Por favor ingrese un titulo.\n");
                            }
                            break;
                        case 2:
                            Console.Write("   Ingrese el la fecha que desea listar (dd-mm): ");
                            string Fecha = Console.ReadLine();
                            DateTime FechaValidada = ValidarFecha.Validar(Fecha); //Valida la fecha y devuelve un DateTime, de no ser valida lanza excepcion con msg
                            Console.WriteLine("");
                            List<FuncionResponse> ListaFuncionResponse2 = await FuncionService.ListarFecha(FechaValidada);
                            ImprimirFunciones.Imprimir(ListaFuncionResponse2);
                            break;
                        case 3:
                            Console.Write("   Ingrese el titulo que desea listar: ");
                            string Titu2 = Console.ReadLine();
                            if (Titu2 != "")
                            {
                                Console.Write("   Ingrese el la fecha que desea listar (dd/mm): ");
                                string Fecha2 = Console.ReadLine();
                                DateTime FechaValidada2 = ValidarFecha.Validar(Fecha2);
                                Console.WriteLine("");
                                List<FuncionResponse> ListaFuncionResponse3 = await FuncionService.ListarTituFecha(Titu2, FechaValidada2);
                                ImprimirFunciones.Imprimir(ListaFuncionResponse3);
                            }
                            else
                            {
                                Console.WriteLine("   Por favor ingrese un titulo.\n");
                            }
                            break;
                        case 4:
                            menu = false;
                            Console.Clear();
                            break;              //no hace nada y vuelve al menu
                        default:
                            Console.WriteLine("   No se ha ingresado una opcion valida.\n");
                            break;
                    }
                }
                catch (ExceptionFecha Ex) 
                {
                    Console.Clear();
                    Console.WriteLine(Ex.Message);
                }
                catch (OverflowException)
                {
                    Console.Clear();
                    Console.WriteLine("   Se han ingresado demasiados datos, error.\n   ");
                }
                catch (FormatException)
                {
                    //Console.Clear();
                    Console.WriteLine("   rokopop.\n   ");
                }
                catch (Exception Ex)
                {
                    Console.Clear();
                    Console.WriteLine("   Ha ocurrido un error inesperado.\n" + Ex.Message);
                }
            }
        }
    




        static async void ListarPeliculas(IPeliculaService PeliculaService) 
        {
            ImprimirPeliculas ImprimirPeliculas = new ImprimirPeliculas();
            List<PeliculaResponse> lista = await PeliculaService.GetAllPeliculas();
            ImprimirPeliculas.Imprimir(lista);
        }

    }
}