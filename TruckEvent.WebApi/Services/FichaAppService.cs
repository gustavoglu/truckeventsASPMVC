using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Infra.Repository.EntityRepository;
using TruckEvent.WebApi.Infra.Repository.EntityRepository.Interfaces;
using TruckEvent.WebApi.Models;
using TruckEvent.WebApi.Services.Interfaces;
using TruckEvent.WebApi.ViewModels;

namespace TruckEvent.WebApi.Services
{
    public class FichaAppService : AppService<Ficha, FichaViewModel>, IFichaAppService
    {
        private readonly IFicha_Repository _fichaRepository;

        public FichaAppService()
        {
            _fichaRepository = new Ficha_Repository();
        }

        public FichaViewModel BuscarPorCodigo(string codigo)
        {
            return Mapper.Map<FichaViewModel>(_fichaRepository.Pesquisar(f => f.Codigo == codigo).SingleOrDefault());
        }


        public IEnumerable<FichaViewModel> TrazerTodosAtivos(Guid id_evento)
        {
            return Mapper.Map<IEnumerable<FichaViewModel>>(_fichaRepository.TrazerTodosAtivos().Where(f => f.Id_Evento == id_evento).ToList());
        }

        public IEnumerable<FichaViewModel> TrazerTodosDeletados(Guid id_evento)
        {
            return Mapper.Map<IEnumerable<FichaViewModel>>(_fichaRepository.TrazerTodosDeletados().Where(f => f.Id_Evento == id_evento).ToList());
        }
    }
}