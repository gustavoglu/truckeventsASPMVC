﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;
using TruckEvent.WebApi.ViewModels;

namespace TruckEvent.WebApi.Services.Interfaces
{
    public interface IFichaAppService : IAppService<Ficha,FichaViewModel>
    {

        FichaViewModel BuscarPorCodigo(string codigo);

        FichaViewModel BuscarAtivoPorCodigo(string codigo);

        FichaViewModel Estornar(FichaViewModel fichaViewModel);

        FichaViewModel Atualizar(FichaViewModel fichaViewModel, double saldoAnterior);

        IEnumerable<FichaViewModel> TrazerTodosAtivos(Guid id_evento);

        IEnumerable<FichaViewModel> TrazerTodosDeletados(Guid id_evento);
    }
}