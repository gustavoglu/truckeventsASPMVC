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
            CreateMap<Consequencia, ConsequenciaViewModel>().ReverseMap();
            CreateMap<Evento, EventoViewModel>().ReverseMap();
            CreateMap<Evento_Usuario, Evento_UsuarioViewModel>().ReverseMap();
            CreateMap<Ficha, FichaViewModel>().ReverseMap();
            CreateMap<Pagamento_Tipo, Pagamento_TipoViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
            CreateMap<Produto_Cor, Produto_CorViewModel>().ReverseMap();
            CreateMap<Produto_Tipo, Produto_TipoViewModel>().ReverseMap();
            CreateMap<Produto_Variacao, Produto_VariacaoViewModel>().ReverseMap();
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
            CreateMap<Usuario_Tipo, Usuario_TipoViewModel>().ReverseMap();
            CreateMap<Venda, VendaViewModel>().ReverseMap();
            CreateMap<Venda_Pagamento, Venda_PagamentoViewModel>().ReverseMap();
            CreateMap<Venda_Produto, Venda_ProdutoViewModel>().ReverseMap();
            CreateMap<Venda_Produto_Variacao, Venda_Produto_VariacaoViewModel>().ReverseMap();
            CreateMap<Ficha_Produto, Ficha_ProdutoViewModel>().ReverseMap();



        }
    }
}