using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;
using TruckEvent.WebApi.ViewModels;

namespace TruckEvent.WebApi.AutoMap
{
    public class ViewModelToModel : Profile
    {
        public ViewModelToModel()
        {
            CreateMap<ConsequenciaViewModel, Consequencia>().ReverseMap()
                .ForMember(c => c.Produto_Variacoes, cfg => cfg.Ignore());

            CreateMap<EventoViewModel, Evento>().ReverseMap()
                .ForMember(e => e.Fichas, cfg => cfg.Ignore())
                .ForMember(e => e.Vendas, cfg => cfg.Ignore())
                .ForMember(e => e.Evento_Usuarios, cfg => cfg.Ignore());

            CreateMap<Evento_UsuarioViewModel, Evento_Usuario>().ReverseMap();

            CreateMap<FichaViewModel, Ficha>().ReverseMap()
                .ForMember(e => e.Ficha_Produtos, cfg => cfg.Ignore())
                .ForMember(e => e.Venda_Pagamento_Fichas, cfg => cfg.Ignore())
                .ForMember(e => e.Movimentacoes, cfg => cfg.Ignore());

            CreateMap<Pagamento_TipoViewModel, Pagamento_Tipo>().ReverseMap()
                .ForMember(e => e.Venda_Pagamentos, cfg => cfg.Ignore());

            CreateMap<ProdutoViewModel, Produto>().ReverseMap()
                .ForMember(e => e.Venda_Produtos, cfg => cfg.Ignore())
                .ForMember(e => e.Ficha_Produtos, cfg => cfg.Ignore());

            CreateMap<Produto_CorViewModel, Produto_Cor>().ReverseMap()
                .ForMember(e => e.Produtos, cfg => cfg.Ignore());

            CreateMap<Produto_TipoViewModel, Produto_Tipo>().ReverseMap()
                      .ForMember(e => e.Produtos, cfg => cfg.Ignore());

            CreateMap<Produto_VariacaoViewModel, Produto_Variacao>().ReverseMap()
                 .ForMember(e => e.Venda_Produto_Variacoes, cfg => cfg.Ignore());

            CreateMap<UsuarioViewModel, Usuario>().ReverseMap()
                .ForMember(e => e.Caixas, cfg => cfg.Ignore())
                .ForMember(e => e.Lojas, cfg => cfg.Ignore())
                .ForMember(e => e.Eventos, cfg => cfg.Ignore())
                .ForMember(e => e.Evento_Usuarios, cfg => cfg.Ignore());

            CreateMap<Usuario_TipoViewModel, Usuario_Tipo>().ReverseMap();

            CreateMap<VendaViewModel, Venda>().ReverseMap()
                 .ForMember(e => e.Venda_Pagamentos, cfg => cfg.Ignore())
                .ForMember(e => e.Venda_Produtos, cfg => cfg.Ignore());

            CreateMap<Venda_PagamentoViewModel, Venda_Pagamento>().ReverseMap()
                      .ForMember(e => e.Venda_Pagamento_Fichas, cfg => cfg.Ignore());

            CreateMap<Venda_Pagamento_FichaViewModel, Venda_Pagamento_Ficha>().ReverseMap();

            CreateMap<Venda_ProdutoViewModel, Venda_Produto>().ReverseMap()
                .ForMember(e => e.Venda_Produto_Variacoes, cfg => cfg.Ignore());

            CreateMap<Venda_Produto_VariacaoViewModel, Venda_Produto_Variacao>().ReverseMap();

            CreateMap<Ficha_ProdutoViewModel, Ficha_Produto>().ReverseMap();

            CreateMap<TokenEnvioViewModel, TokenEnvio>().ReverseMap();

            CreateMap<MovimentacaoViewModel, Movimentacao>().ReverseMap();

        }


    }
}