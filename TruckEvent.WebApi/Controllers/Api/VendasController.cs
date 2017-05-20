using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TruckEvent.WebApi.Infra;
using TruckEvent.WebApi.Services;
using TruckEvent.WebApi.Services.Interfaces;
using TruckEvent.WebApi.ViewModels;

namespace TruckEvent.WebApi.Controllers.Api
{
    [RoutePrefix("api/Vendas")]
    public class VendasController : ApiController
    {
        private SQLContext db = new SQLContext();
        private readonly IFichaAppService _fichaAppService = new FichaAppService();

        private readonly IVendaAppService _vendaAppService = new VendaAppService();

        // GET: api/Vendas
        public IQueryable<VendaViewModel> GetVendaViewModels()
        {
            return _vendaAppService.TrazerTodosAtivos().ToList().AsQueryable();
        }

        // GET: api/Vendas/5
        [ResponseType(typeof(VendaViewModel))]
        public IHttpActionResult GetVendaViewModel(Guid id)
        {
            VendaViewModel vendaViewModel = _vendaAppService.BuscarPorId(id);
            if (vendaViewModel == null)
            {
                return NotFound();
            }

            return Ok(vendaViewModel);
        }

        // PUT: api/Vendas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVendaViewModel(Guid id, VendaViewModel vendaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vendaViewModel.Id || !VendaViewModelExists(id))
            {
                return BadRequest();
            }
            _vendaAppService.Atualizar(vendaViewModel);

            return StatusCode(HttpStatusCode.NoContent);
        }


        [HttpPut]
        [Route("cancelar/{id}")]
        public IHttpActionResult PutCancelaVenda(Guid id)
        {
            return Ok (_vendaAppService.Calcelar(id));
        }

        // POST: api/Vendas
        [ResponseType(typeof(VendaViewModel))]
        public IHttpActionResult PostVendaViewModel(VendaViewModel vendaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fichasPagamentos = new List<FichaViewModel>();

            foreach (var item in vendaViewModel.Venda_Pagamentos)
            {
                foreach (var pagamentoFicha in item.Venda_Pagamento_Fichas)
                {
                    var ficha = _fichaAppService.BuscarPorId(pagamentoFicha.Id_Ficha.Value);

                    if (ficha != null)
                    {
                        fichasPagamentos.Add(ficha);
                    }
                }
            }

            if (!(vendaViewModel.Venda_Produtos.Count > 0))
            {
                return BadRequest("Uma venda precisa ter Produtos Vendidos");
            }

            if (!(vendaViewModel.Venda_Pagamentos.Count > 0))
            {
                return BadRequest("Uma venda precisa ter Pagamentos");
            }

            //Verifica se a soma das fichas dessa venda tem saldo para o total da venda
            double somaSaldoFichas = 0;

            foreach (var ficha in fichasPagamentos)
            {
                if (ficha.Saldo > 0)
                {
                    somaSaldoFichas = somaSaldoFichas + ficha.Saldo.Value;
                }
            }

            //Verifica se alguma das fichas usadas contem saldo
            if (!(somaSaldoFichas > 0))
            {
                return BadRequest("Não existe saldo na(s) Ficha(s) informada(s)");
            }

            if (!(somaSaldoFichas > 0) && !(somaSaldoFichas >= vendaViewModel.TotalVenda))
            {
                return BadRequest(string.Format("A(s) Ficha(s) não contem saldo para esta Venda, total saldo da(s) Ficha(s) : {0}, total Venda: {1}", somaSaldoFichas, vendaViewModel.TotalVenda));
            }

            var venda = _vendaAppService.Criar(vendaViewModel);

            return Ok(venda);
        }

        // DELETE: api/Vendas/5
        [ResponseType(typeof(VendaViewModel))]
        public IHttpActionResult DeleteVendaViewModel(Guid id)
        {
            VendaViewModel vendaViewModel = _vendaAppService.BuscarPorId(id);
            if (vendaViewModel == null)
            {
                return NotFound();
            }

            _vendaAppService.Deletar(id);

            return Ok(vendaViewModel);
        }

        [HttpGet]
        [Route("evento/{id_evento}")]
        public IQueryable<VendaViewModel> GetVendasEvento(Guid id_evento)
        {
            return _vendaAppService.TrazerVendasDeEvento(id_evento).AsQueryable();
        }

        protected override void Dispose(bool disposing)
        {
            _vendaAppService.Dispose();
            base.Dispose(disposing);
        }

        private bool VendaViewModelExists(Guid? id)
        {
            return db.Vendas.Count(e => e.Id == id) > 0;
        }
    }
}