using Application.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_ORM_Duarte_Rodrigo
{
    public class ImprimirFunciones
    {
        public void Imprimir(List<FuncionResponse> ListaFuncionesResponse) 
        {
            Console.WriteLine("   La lista tiene " + ListaFuncionesResponse.Count + " funciones\n");
            if (ListaFuncionesResponse.Count != 0)
            {
                foreach (FuncionResponse Fun in ListaFuncionesResponse)
                {
                    Console.WriteLine("   Titulo: " + Fun.PeliculaNombre + "\nSinopsis: " + "\nGenero: " + Fun.Genero + "\n");
                    Console.WriteLine("   Sala: " + Fun.SalaNombre + " - Fecha: " + Fun.Fecha.ToString("dddd") + " " + Fun.Fecha.ToString("dd/MM/yyyy") + " - Horario: " + Fun.Horario.ToString("HH:mm"));
                }
                Console.WriteLine("\n\n");
            }
            else
            {
                Console.WriteLine("   No hay funciones para esa pelicula\n");
            }
        }
    }
}
