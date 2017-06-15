using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;
using TruckEvent.WebApi.ViewModels;

namespace TruckEvent.WebApi.AutoMap
{
    public class ProfileAutoMapper : Profile
    {
        public ProfileAutoMapper()
        {
            #region ViewModel para Model

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


            #endregion

            #region Model para ViewModel

            CreateMap<ConsequenciaViewModel, Consequencia>()
             .ForMember(c => c.DeletadoEm, cfg => cfg.Ignore())
             .ForMember(c => c.DeletadoPor, cfg => cfg.Ignore())
             .ForMember(c => c.AtualizadoEm, cfg => cfg.Ignore())
             .ForMember(c => c.AtualizadoPor, cfg => cfg.Ignore())
             .ForMember(c => c.CriadoEm, cfg => cfg.Ignore())
             .ForMember(c => c.CriadoPor, cfg => cfg.Ignore())
             .ForMember(c => c.Produto_Variacoes, cfg => cfg.Ignore());

            CreateMap<EventoViewModel, Evento>()
              .ForMember(c => c.DeletadoEm, cfg => cfg.Ignore())
              .ForMember(c => c.DeletadoPor, cfg => cfg.Ignore())
              .ForMember(c => c.AtualizadoEm, cfg => cfg.Ignore())
              .ForMember(c => c.AtualizadoPor, cfg => cfg.Ignore())
              .ForMember(c => c.CriadoEm, cfg => cfg.Ignore())
              .ForMember(c => c.CriadoPor, cfg => cfg.Ignore())
              .ForMember(e => e.Fichas, cfg => cfg.Ignore())
              .ForMember(e => e.Vendas, cfg => cfg.Ignore())
              .ForMember(e => e.Evento_Usuarios, cfg => cfg.Ignore());

            CreateMap<Evento_UsuarioViewModel, Evento_Usuario>()
              .ForMember(c => c.DeletadoEm, cfg => cfg.Ignore())
              .ForMember(c => c.DeletadoPor, cfg => cfg.Ignore())
              .ForMember(c => c.AtualizadoEm, cfg => cfg.Ignore())
              .ForMember(c => c.AtualizadoPor, cfg => cfg.Ignore())
              .ForMember(c => c.CriadoEm, cfg => cfg.Ignore())
              .ForMember(c => c.CriadoPor, cfg => cfg.Ignore());

            CreateMap<FichaViewModel, Ficha>()
                .ForMember(c => c.DeletadoEm, cfg => cfg.Ignore())
                .ForMember(c => c.DeletadoPor, cfg => cfg.Ignore())
                .ForMember(c => c.AtualizadoEm, cfg => cfg.Ignore())
                .ForMember(c => c.AtualizadoPor, cfg => cfg.Ignore())
                .ForMember(c => c.CriadoEm, cfg => cfg.Ignore())
                .ForMember(c => c.CriadoPor, cfg => cfg.Ignore())
                .ForMember(e => e.Evento, cfg => cfg.Ignore())
                .ForMember(e => e.Ficha_Produtos, cfg => cfg.Ignore())
                .ForMember(e => e.Venda_Pagamento_Fichas, cfg => cfg.Ignore())
                .ForMember(e => e.Movimentacoes, cfg => cfg.Ignore());

            CreateMap<Pagamento_TipoViewModel, Pagamento_Tipo>()
              .ForMember(c => c.DeletadoEm, cfg => cfg.Ignore())
              .ForMember(c => c.DeletadoPor, cfg => cfg.Ignore())
              .ForMember(c => c.AtualizadoEm, cfg => cfg.Ignore())
              .ForMember(c => c.AtualizadoPor, cfg => cfg.Ignore())
              .ForMember(c => c.CriadoEm, cfg => cfg.Ignore())
              .ForMember(c => c.CriadoPor, cfg => cfg.Ignore());
            //.ForMember(e => e.Venda_Pagamentos, cfg => cfg.Ignore());

            CreateMap<ProdutoViewModel, Produto>()
              .ForMember(c => c.DeletadoEm, cfg => cfg.Ignore())
              .ForMember(c => c.DeletadoPor, cfg => cfg.Ignore())
              .ForMember(c => c.AtualizadoEm, cfg => cfg.Ignore())
              .ForMember(c => c.AtualizadoPor, cfg => cfg.Ignore())
              .ForMember(c => c.CriadoEm, cfg => cfg.Ignore())
              .ForMember(c => c.CriadoPor, cfg => cfg.Ignore())
              .ForMember(e => e.Venda_Produtos, cfg => cfg.Ignore())
              .ForMember(e => e.Ficha_Produtos, cfg => cfg.Ignore());

            CreateMap<Produto_CorViewModel, Produto_Cor>()
              .ForMember(c => c.DeletadoEm, cfg => cfg.Ignore())
              .ForMember(c => c.DeletadoPor, cfg => cfg.Ignore())
              .ForMember(c => c.AtualizadoEm, cfg => cfg.Ignore())
              .ForMember(c => c.AtualizadoPor, cfg => cfg.Ignore())
              .ForMember(c => c.CriadoEm, cfg => cfg.Ignore())
              .ForMember(c => c.CriadoPor, cfg => cfg.Ignore())
              .ForMember(e => e.Produtos, cfg => cfg.Ignore());

            CreateMap<Produto_TipoViewModel, Produto_Tipo>()
                  .ForMember(c => c.DeletadoEm, cfg => cfg.Ignore())
                  .ForMember(c => c.DeletadoPor, cfg => cfg.Ignore())
                  .ForMember(c => c.AtualizadoEm, cfg => cfg.Ignore())
                  .ForMember(c => c.AtualizadoPor, cfg => cfg.Ignore())
                  .ForMember(c => c.CriadoEm, cfg => cfg.Ignore())
                  .ForMember(c => c.CriadoPor, cfg => cfg.Ignore())
                  .ForMember(e => e.Produtos, cfg => cfg.Ignore());

            CreateMap<Produto_VariacaoViewModel, Produto_Variacao>()
                      .ForMember(c => c.DeletadoEm, cfg => cfg.Ignore())
                      .ForMember(c => c.DeletadoPor, cfg => cfg.Ignore())
                      .ForMember(c => c.AtualizadoEm, cfg => cfg.Ignore())
                      .ForMember(c => c.AtualizadoPor, cfg => cfg.Ignore())
                      .ForMember(c => c.CriadoEm, cfg => cfg.Ignore())
                      .ForMember(c => c.CriadoPor, cfg => cfg.Ignore())
                      .ForMember(e => e.Venda_Produto_Variacoes, cfg => cfg.Ignore());

            CreateMap<UsuarioViewModel, Usuario>()
                .ForMember(e => e.Caixas, cfg => cfg.Ignore())
                .ForMember(e => e.Lojas, cfg => cfg.Ignore())
                .ForMember(e => e.Eventos, cfg => cfg.Ignore())
                .ForMember(e => e.Evento_Usuarios, cfg => cfg.Ignore());

            CreateMap<Usuario_TipoViewModel, Usuario_Tipo>()
                    .ForMember(c => c.DeletadoEm, cfg => cfg.Ignore())
                    .ForMember(c => c.DeletadoPor, cfg => cfg.Ignore())
                    .ForMember(c => c.AtualizadoEm, cfg => cfg.Ignore())
                    .ForMember(c => c.AtualizadoPor, cfg => cfg.Ignore())
                    .ForMember(c => c.CriadoEm, cfg => cfg.Ignore())
                    .ForMember(c => c.CriadoPor, cfg => cfg.Ignore());

            CreateMap<VendaViewModel, Venda>()
                      .ForMember(c => c.DeletadoEm, cfg => cfg.Ignore())
                      .ForMember(c => c.DeletadoPor, cfg => cfg.Ignore())
                      .ForMember(c => c.AtualizadoEm, cfg => cfg.Ignore())
                      .ForMember(c => c.AtualizadoPor, cfg => cfg.Ignore())
                      .ForMember(c => c.CriadoEm, cfg => cfg.Ignore())
                      .ForMember(c => c.CriadoPor, cfg => cfg.Ignore())
                      .ForMember(c => c.Evento, cfg => cfg.Ignore())
                      .ForMember(e => e.Venda_Pagamentos, cfg => cfg.Ignore())
                      .ForMember(e => e.Venda_Produtos, cfg => cfg.Ignore());

            CreateMap<Venda_PagamentoViewModel, Venda_Pagamento>()
                      .ForMember(c => c.DeletadoEm, cfg => cfg.Ignore())
                      .ForMember(c => c.DeletadoPor, cfg => cfg.Ignore())
                      .ForMember(c => c.AtualizadoEm, cfg => cfg.Ignore())
                      .ForMember(c => c.AtualizadoPor, cfg => cfg.Ignore())
                      .ForMember(c => c.CriadoEm, cfg => cfg.Ignore())
                      .ForMember(c => c.CriadoPor, cfg => cfg.Ignore())
                      .ForMember(c => c.Venda, cfg => cfg.Ignore())
                      .ForMember(e => e.Venda_Pagamento_Fichas, cfg => cfg.Ignore());

            CreateMap<Venda_Pagamento_FichaViewModel, Venda_Pagamento_Ficha>()
                      .ForMember(c => c.DeletadoEm, cfg => cfg.Ignore())
                      .ForMember(c => c.DeletadoPor, cfg => cfg.Ignore())
                      .ForMember(c => c.AtualizadoEm, cfg => cfg.Ignore())
                      .ForMember(c => c.AtualizadoPor, cfg => cfg.Ignore())
                      .ForMember(c => c.CriadoEm, cfg => cfg.Ignore())
                      .ForMember(c => c.Venda_Pagamento, cfg => cfg.Ignore())
                      .ForMember(c => c.Ficha, cfg => cfg.Ignore())
                      .ForMember(c => c.CriadoPor, cfg => cfg.Ignore());

            CreateMap<Venda_ProdutoViewModel, Venda_Produto>()
                  .ForMember(c => c.DeletadoEm, cfg => cfg.Ignore())
                  .ForMember(c => c.DeletadoPor, cfg => cfg.Ignore())
                  .ForMember(c => c.AtualizadoEm, cfg => cfg.Ignore())
                  .ForMember(c => c.AtualizadoPor, cfg => cfg.Ignore())
                  .ForMember(c => c.CriadoEm, cfg => cfg.Ignore())
                  .ForMember(c => c.CriadoPor, cfg => cfg.Ignore())
                  .ForMember(c => c.Venda, cfg => cfg.Ignore())
                  .ForMember(c => c.Produto, cfg => cfg.Ignore())
                  .ForMember(e => e.Venda_Produto_Variacoes, cfg => cfg.Ignore());

            CreateMap<Venda_Produto_VariacaoViewModel, Venda_Produto_Variacao>()
                    .ForMember(c => c.DeletadoEm, cfg => cfg.Ignore())
                      .ForMember(c => c.DeletadoPor, cfg => cfg.Ignore())
                      .ForMember(c => c.AtualizadoEm, cfg => cfg.Ignore())
                      .ForMember(c => c.AtualizadoPor, cfg => cfg.Ignore())
                      .ForMember(c => c.CriadoEm, cfg => cfg.Ignore())
                      .ForMember(c => c.CriadoPor, cfg => cfg.Ignore());

            CreateMap<Ficha_ProdutoViewModel, Ficha_Produto>()
                    .ForMember(c => c.DeletadoEm, cfg => cfg.Ignore())
                    .ForMember(c => c.DeletadoPor, cfg => cfg.Ignore())
                    .ForMember(c => c.AtualizadoEm, cfg => cfg.Ignore())
                    .ForMember(c => c.AtualizadoPor, cfg => cfg.Ignore())
                    .ForMember(c => c.CriadoEm, cfg => cfg.Ignore())
                    .ForMember(c => c.CriadoPor, cfg => cfg.Ignore());

            CreateMap<TokenEnvioViewModel, TokenEnvio>()
                    .ForMember(c => c.DeletadoEm, cfg => cfg.Ignore())
                    .ForMember(c => c.DeletadoPor, cfg => cfg.Ignore())
                    .ForMember(c => c.AtualizadoEm, cfg => cfg.Ignore())
                    .ForMember(c => c.AtualizadoPor, cfg => cfg.Ignore())
                    .ForMember(c => c.CriadoEm, cfg => cfg.Ignore())
                    .ForMember(c => c.CriadoPor, cfg => cfg.Ignore());

            CreateMap<MovimentacaoViewModel, Movimentacao>()
                    .ForMember(c => c.DeletadoEm, cfg => cfg.Ignore())
                    .ForMember(c => c.DeletadoPor, cfg => cfg.Ignore())
                    .ForMember(c => c.AtualizadoEm, cfg => cfg.Ignore())
                    .ForMember(c => c.AtualizadoPor, cfg => cfg.Ignore())
                    .ForMember(c => c.CriadoEm, cfg => cfg.Ignore())
                    .ForMember(c => c.CriadoPor, cfg => cfg.Ignore());

            #endregion

        }


    }
}