using Domain.Entities;
using Infraestructure;
using System.Collections.Generic;

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
                    using (var ctx = new CineContext())
                    {
                        Thread.Sleep(5000);
                        Console.Clear();
                        Console.WriteLine("Bienvenidos al cine\n");
                        Console.WriteLine("Por favor elija una opcion");
                        Console.WriteLine("1 - Listar funciones");
                        Console.WriteLine("2 - Registrar funcion");
                        Console.WriteLine("3 - Salir\n");
                        Console.Write("Ingrese una opcion: ");
                        int opcion = int.Parse(Console.ReadLine());
                        Console.WriteLine("");
                        switch (opcion)
                        {
                            case 1:
                                listar(ctx);
                                break;
                            case 2:
                                //IAddFuntion repo2 = new repoAddFuntion(ctx);
                                //IMetoAddFuntion generador = new AddFuntion(repo2);
                                //generador.addFuntion();
                                break;
                            case 3:
                                menu = false;
                                break;
                            default:
                                Console.WriteLine("El número no coincide con ningún caso.\n");
                                break;
                        }
                    }
                }
                catch (OverflowException)
                {
                    Console.Clear();
                    Console.WriteLine("Se han ingresado demasiados datos, error.\n");
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Por favor ingrese un numero.\n");
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Ha ocurrido un error inesperado.\n");
                }
            }
            Console.WriteLine("Gracias por utilizar nuestros servicios. Que tenga un buen dia :)");
        }



        static void listar(CineContext ctx)
        {
            bool menu = true;
            while (menu)
            {
                try
                {
                    Console.WriteLine("opciones de listado:\n");
                    Console.WriteLine("1 - Listar por titulo");
                    Console.WriteLine("2 - Listar por dia");
                    Console.WriteLine("3 - Listar por titulo y dia");
                    Console.WriteLine("4 - volver al menu\n");
                    //IFuncionService FuncionService = new FuncionService(ctx);
                    Console.Write("Ingrese una opcion: ");
                    int opcion2 = int.Parse(Console.ReadLine());
                    switch (opcion2)
                    {
                        case 1:
                            Console.Write("Ingrese el titulo que desea listar: ");
                            string titu = Console.ReadLine();
                            Console.WriteLine("");
                            //FuncionService.ListarTitu(titu);
                            break;
                        case 2:
                            Console.Write("Ingrese el la fecha que desea listar (dd/mm): ");
                            string fecha = Console.ReadLine();
                            Console.WriteLine("");
                            //FuncionService.ListarFecha();
                            break;
                        case 3:
                            Console.Write("Ingrese el titulo que desea listar: ");
                            string titu2 = Console.ReadLine();
                            Console.Write("Ingrese el la fecha que desea listar (dd/mm): ");
                            string fecha2 = Console.ReadLine();
                            Console.WriteLine("");
                            //FuncionService.ListarTituFecha(titu2, fecha2);
                            break;
                        case 4:
                            menu = false;
                            Console.Clear();
                            break;              //no hace nada y vuelve al menu
                        default:
                            Console.WriteLine("El número no coincide con ningún caso.\n");
                            break;
                    }
                }
                catch (OverflowException)
                {
                    Console.Clear();
                    Console.WriteLine("Se han ingresado demasiados datos, error.\n");
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Por favor ingrese un numero.\n");
                }
            }
        }
    }
}