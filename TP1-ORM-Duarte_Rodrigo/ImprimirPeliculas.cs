using Application.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_ORM_Duarte_Rodrigo
{
    public class ImprimirPeliculas
    {
        public async void Imprimir(List<PeliculaResponse> ListaPeliculasResponse)
        {
            if (ListaPeliculasResponse.Count != 0)
            {
                foreach (PeliculaResponse Pel in ListaPeliculasResponse)
                {
                    Console.WriteLine("   Titulo: " + Pel.Titulo);
                    Console.WriteLine("   Sinopsis: " + Pel.Sinopsis);
                    Console.WriteLine("   Trailer: " + Pel.Trailer);
                    Console.WriteLine("   Poster: " + Pel.Poster);
                    Console.WriteLine("   Genero: " + Pel.Genero);
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
