using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Infra.Repository.EntityRepository.Interfaces;
using TruckEvent.WebApi.Models;
using TruckEvent.WebApi.Services.Interfaces;
using TruckEvent.WebApi.ViewModels;

namespace TruckEvent.WebApi.Services
{
    public class TokenEnvioAppService : ITokenEnvioAppService
    {

        private readonly ITokenEnvioRepository _tokenEnvioRepository;
        public TokenEnvioAppService()
        {
            _tokenEnvioRepository = new TokenEnvioRepository();
        }

        public TokenEnvioViewModel Atualizar(TokenEnvioViewModel tokenEnvioViewModel)
        {
            var tokenEnvio = Mapper.Map<TokenEnvio>(tokenEnvioViewModel);
            return Mapper.Map<TokenEnvioViewModel>(_tokenEnvioRepository.Atualizar(tokenEnvio));

        }

        public TokenEnvioViewModel BuscarPorId(Guid Id)
        {
            return Mapper.Map<TokenEnvioViewModel>(_tokenEnvioRepository.BuscarPorId(Id));
        }

        public TokenEnvioViewModel Criar(TokenEnvioViewModel tokenEnvioViewModel)
        {
            var tokenEnvio = Mapper.Map<TokenEnvio>(tokenEnvioViewModel);
            return Mapper.Map<TokenEnvioViewModel>(_tokenEnvioRepository.Criar(tokenEnvio));
        }

        public bool Deletar(Guid Id)
        {
            return _tokenEnvioRepository.Deletar(Id);
        }

        public void Dispose()
        {
            _tokenEnvioRepository.Dispose();
        }

        public TokenEnvioViewModel Reativar(Guid Id)
        {
            return Mapper.Map<TokenEnvioViewModel>(_tokenEnvioRepository.Reativar(Id));
        }

        public IEnumerable<TokenEnvioViewModel> TrazerTodosAtivos()
        {
            return Mapper.Map<IEnumerable<TokenEnvioViewModel>>(_tokenEnvioRepository.TrazerTodosAtivos());

        }

        public IEnumerable<TokenEnvioViewModel> TrazerTodosDeletados()
        {
            return Mapper.Map<IEnumerable<TokenEnvioViewModel>>(_tokenEnvioRepository.TrazerTodosDeletados());
        }
    }
}