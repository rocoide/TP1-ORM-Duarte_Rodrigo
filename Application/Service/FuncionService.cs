﻿using Application.Interface.Function;
using Application.Model.DTO;
using Application.Model.Response;
using Domain.Entity;

namespace Application.Service
{
    public class FuncionService : IFuncionService
    {
        private readonly IFuncionCommand FuncionCommand;
        private readonly IFuncionQuery FuncionQuery;

        public FuncionService(IFuncionCommand FuncionCommand, IFuncionQuery FuncionQuery)
        {
            this.FuncionCommand = FuncionCommand;
            this.FuncionQuery = FuncionQuery;
        }

        public async Task<List<FuncionResponse>> ListarTitu(string Titu)
        {
            List<Funcion> ListaFuncion = await FuncionQuery.ListarTitu(Titu);
            List<FuncionResponse> ListaResponse = new List<FuncionResponse>();
            FuncionResponse FunResponse;
            foreach (Funcion Fun in ListaFuncion)
            {
                FunResponse = new FuncionResponse
                {
                    PeliculaNombre = Fun.Peliculas.Titulo,
                    SalaNombre = Fun.Salas.Nombre,
                    Genero = Fun.Peliculas.Generos.Nombre,
                    Fecha = Fun.Fecha,
                    Horario = Fun.Horario
                };
                ListaResponse.Add(FunResponse);
            }
            return ListaResponse;
        }

        public async Task<List<FuncionResponse>> ListarFecha(DateTime Fecha)
        {
            List<Funcion> ListaFuncion = await FuncionQuery.ListarFecha(Fecha);
            List<FuncionResponse> ListaResponse = new List<FuncionResponse>();
            FuncionResponse FunResponse;
            foreach (Funcion Fun in ListaFuncion)
            {
                FunResponse = new FuncionResponse
                {
                    PeliculaNombre = Fun.Peliculas.Titulo,
                    SalaNombre = Fun.Salas.Nombre,
                    Genero = Fun.Peliculas.Generos.Nombre,
                    Fecha = Fun.Fecha,
                    Horario = Fun.Horario
                };
                ListaResponse.Add(FunResponse);
            }
            return ListaResponse;
        }

        public async Task<List<FuncionResponse>> ListarTituFecha(string Titu, DateTime Fecha)
        {
            List<Funcion> ListaFuncion = await FuncionQuery.ListarTituFecha(Titu, Fecha);
            List<FuncionResponse> ListaResponse = new List<FuncionResponse>();
            FuncionResponse FunResponse;
            foreach (Funcion Fun in ListaFuncion)
            {
                FunResponse = new FuncionResponse
                {
                    PeliculaNombre = Fun.Peliculas.Titulo,
                    SalaNombre = Fun.Salas.Nombre,
                    Genero = Fun.Peliculas.Generos.Nombre,
                    Fecha = Fun.Fecha,
                    Horario = Fun.Horario
                };
                ListaResponse.Add(FunResponse);
            }
            return ListaResponse;
        }

        public void AddFuncion(FuncionDto FuncionDto)
        {
            Funcion Funcion = new Funcion
            {
                PeliculaId = FuncionDto.PeliculaId,
                SalaId = FuncionDto.SalaId,
                Fecha = FuncionDto.Fecha,
                Horario = FuncionDto.Horario
            };
            FuncionCommand.AddFuncion(Funcion);
        }
    }
}
