﻿using Application.Model.Response;

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
                    Console.WriteLine("   Pelicula: " + Pel.PeliculaId);
                    Console.WriteLine("   Titulo: " + Pel.Titulo);
                    Console.WriteLine("   Sinopsis: " + Pel.Sinopsis);
                    Console.WriteLine("   Trailer: " + Pel.Trailer);
                    Console.WriteLine("   Poster: " + Pel.Poster);
                    Console.WriteLine("   Genero: " + Pel.Genero);
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("   No hay peliculas registradas.\n");
            }
        }
    }
}
