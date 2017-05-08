using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.ViewModels;

namespace TruckEvent.WebApi.Services.Interfaces
{
    public interface IVenda_Pagamento_FichaAppService : IDisposable
    {
        Venda_Pagamento_FichaViewModel Criar(Venda_Pagamento_FichaViewModel venda_Pagamento_FichaViewModel);

        Venda_Pagamento_FichaViewModel Atualizar(Venda_Pagamento_FichaViewModel venda_Pagamento_FichaViewModel);

        Venda_Pagamento_FichaViewModel BuscarPorId(Guid Id);

        Venda_Pagamento_FichaViewModel Reativar(Guid Id);

        bool Deletar(Guid Id);

        IEnumerable<Venda_Pagamento_FichaViewModel> TrazerTodosAtivos();

        IEnumerable<Venda_Pagamento_FichaViewModel> TrazerTodosDeletados();
    }
}