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
            if (ListaFuncionesResponse.Count != 0)
            {
                foreach (FuncionResponse Fun in ListaFuncionesResponse)
                {
                    Console.WriteLine("   Titulo: " + Fun.PeliculaNombre);
                    Console.WriteLine("   Genero: " + Fun.Genero);
                    Console.WriteLine("   Sala: " + Fun.SalaNombre);
                    Console.WriteLine("   Fecha: " + Fun.Fecha.ToString("dddd") + " " + Fun.Fecha.ToString("dd/MM/yyyy") + " " + Fun.Horario.ToString(@"hh\:mm"));
                    Console.WriteLine("");
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
