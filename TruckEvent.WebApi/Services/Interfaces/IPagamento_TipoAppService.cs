using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.ViewModels;

namespace TruckEvent.WebApi.Services.Interfaces
{
    public interface IPagamento_TipoAppService : IDisposable
    {
        Pagamento_TipoViewModel Criar(Pagamento_TipoViewModel pagamento_TipoViewModel);

        Pagamento_TipoViewModel Atualizar(Pagamento_TipoViewModel pagamento_TipoViewModel);

        Pagamento_TipoViewModel BuscarPorId(Guid Id);

        Pagamento_TipoViewModel Reativar(Guid Id);

        bool Deletar(Guid Id);

        IEnumerable<Pagamento_TipoViewModel> TrazerTodosAtivos();

        IEnumerable<Pagamento_TipoViewModel> TrazerTodosDeletados();
    }
}