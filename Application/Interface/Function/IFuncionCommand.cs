﻿using Application.Model.DTO;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.Function
{
    public interface IFuncionCommand
    {
        void AddFuncion(Funcion Funcion);
    }
}
