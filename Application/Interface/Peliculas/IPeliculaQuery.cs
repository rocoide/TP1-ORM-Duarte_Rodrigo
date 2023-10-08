﻿using Application.Model.Response;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.Peliculas
{
    public interface IPeliculaQuery
    {
        Task<List<Pelicula>> GetAllPeliculas();
    }
}