using Application.Exceptions;
using Application.Interface.Function;
using Application.Interface.Peliculas;
using Application.Interface.Salas;
using Application.Model.DTO;
using Application.Model.Response;
using Application.Validacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_ORM_Duarte_Rodrigo
{
    public class AddFuncion
    {
        private readonly IFuncionService FuncionService;
        private readonly IPeliculaService PeliculaService;
        private readonly ISalaService SalaService;

        public AddFuncion (IFuncionService funcionService, IPeliculaService peliculaService, ISalaService salaService)
        {
            FuncionService = funcionService;
            PeliculaService = peliculaService;
            SalaService = salaService;
        }

        public async void Add() 
        {
            try 
            { 
                Console.Write("   Seleccione ID de una pelicula para la funcion: ");
                int PeliculaId;
                bool Aux = int.TryParse(Console.ReadLine(), out PeliculaId);    //Valido que sea un numero
                if (!Aux)
                {
                    throw new FormatException("   Por favor ingrese un numero para la pelicula.");
                }
                PeliculaResponse? PeliculaResponse = await PeliculaService.GetPeliculaById(PeliculaId);
                if (PeliculaResponse == null)
                {
                    throw new FormatException("   La pelicula ingresada no existe.\n");
                }




                ImprimirSalas ImprimirSalas = new ImprimirSalas();
                ImprimirSalas.Imprimir(await SalaService.GetAllSalas());
                Console.Write("   Seleccione una sala para la funcion: ");
                int SalaId;
                Aux = int.TryParse(Console.ReadLine(), out SalaId);
                if (!Aux) 
                {
                    throw new FormatException("   Por favor ingrese un numero para la sala");
                }
                SalaResponse? SalaResponse = await SalaService.GetSalaById(SalaId);
                if (SalaResponse == null)
                {
                    throw new FormatException("   La sala seleccionada no existe.\n");
                }

                Console.Write("   Ingrese una fecha en el formate dd-mm: ");
                string Fech = Console.ReadLine();
                DateTime Fecha = ValidarFecha.Validar(Fech);
                Console.Write("   Ingrese un horario en el formato: ");
                string Hora = Console.ReadLine();
                TimeSpan Horario = ValidarHorario.Validar(Hora);

                FuncionDto FuncionDto = new FuncionDto
                {
                    PeliculaId = PeliculaId,
                    SalaId = SalaId,
                    Fecha = Fecha,
                    Horario = Horario
                };

                FuncionService.AddFuncion(FuncionDto);


            }
            catch (ExcepcionHorario Ex) 
            {
                Console.Clear();
                Console.WriteLine(Ex.Message);
            }
            catch (ExceptionFecha Ex) 
            {
                Console.Clear();
                Console.WriteLine(Ex.Message);
            }
            catch (OverflowException) 
            {
                Console.Clear();
                Console.WriteLine("   Error, se han ingresado demasiados datos.\n");
            }
            catch (FormatException Ex) 
            {
                Console.Clear();
                Console.WriteLine(Ex.Message);
            }
            catch (NullReferenceException Ex) 
            {
                Console.Clear();
                Console.WriteLine(Ex.Message);
            }
            catch (Exception Ex) 
            {
                Console.Clear();
                Console.WriteLine(Ex.Message);
            }
        }
    }
}
