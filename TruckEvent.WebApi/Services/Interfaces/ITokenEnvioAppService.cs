using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.ViewModels;

namespace TruckEvent.WebApi.Services.Interfaces
{
    public interface ITokenEnvioAppService : IDisposable
    {
        TokenEnvioViewModel Criar(TokenEnvioViewModel tokenEnvioViewModel);

        TokenEnvioViewModel Atualizar(TokenEnvioViewModel tokenEnvioViewModel);

        TokenEnvioViewModel BuscarPorId(Guid Id);

        TokenEnvioViewModel Reativar(Guid Id);

        bool Deletar(Guid Id);

        IEnumerable<TokenEnvioViewModel> TrazerTodosAtivos();

        IEnumerable<TokenEnvioViewModel> TrazerTodosDeletados();
    }
}