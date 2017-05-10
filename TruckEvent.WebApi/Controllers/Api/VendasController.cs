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
            VendaViewModel vendaViewModel =_vendaAppService.BuscarPorId(id);
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

        // POST: api/Vendas
        [ResponseType(typeof(VendaViewModel))]
        public IHttpActionResult PostVendaViewModel(VendaViewModel vendaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!(vendaViewModel.Venda_Produtos.Count > 0))
            {
                return BadRequest("Uma venda precisa ter Produtos Vendidos");
            }

            if (!(vendaViewModel.Venda_Pagamentos.Count > 0))
            {
                return BadRequest("Uma venda precisa ter Pagamentos");
            }

            //Verifica se alguma das fichas usadas contem saldo
            if(!vendaViewModel.Venda_Pagamentos.ToList().Exists(vp => vp.Venda_Pagamento_Fichas.Where(vpf => vpf.Ficha.Saldo > 0).Count() > 0))
            {
                return BadRequest("Não existe saldo na(s) Ficha(s) informada(s)");
            }

            //Verifica se a soma das fichas dessa venda tem saldo para o total da venda
            double somaSaldoFichas = 0;

            foreach (var venda_pagamento in vendaViewModel.Venda_Pagamentos)
            {
                foreach (var venda_pagamento_ficha in venda_pagamento.Venda_Pagamento_Fichas)
                {
                    if (venda_pagamento_ficha.Ficha.Saldo > 0)
                    {
                        somaSaldoFichas = somaSaldoFichas + venda_pagamento_ficha.Ficha.Saldo.Value;
                    }
                }
            }

            if (!(somaSaldoFichas > 0) && !(somaSaldoFichas >= vendaViewModel.TotalVenda))
            {
                return BadRequest(string.Format("A(s) Ficha(s) não contem saldo para esta Venda, total saldo da(s) Ficha(s) : {0}, total Venda: {1}",somaSaldoFichas,vendaViewModel.TotalVenda));
            }


            _vendaAppService.Criar(vendaViewModel);


            //Atualiza Saldo das Fichas
            foreach (var pagamentos in vendaViewModel.Venda_Pagamentos)
            {
                double? pagamento = vendaViewModel.TotalVenda.Value;

                foreach (var pagamentoficha in pagamentos.Venda_Pagamento_Fichas)
                {
                    while (pagamento > 0)
                    {

                        if (pagamentoficha.Ficha.Saldo >= pagamento)
                        {
                            var descontado = pagamentoficha.Ficha.Saldo - pagamento;
                            pagamentoficha.Ficha.Saldo = descontado;
                            _fichaAppService.Atualizar(Mapper.Map<FichaViewModel>(pagamentoficha.Ficha));
                            pagamento = 0;
                        }
                        else
                        {
                            var descontado = pagamento - pagamentoficha.Ficha.Saldo;
                            pagamentoficha.Ficha.Saldo = 0;
                            _fichaAppService.Atualizar(Mapper.Map<FichaViewModel>(pagamentoficha.Ficha));
                            pagamento = descontado;
                        }

                    }
                }

            }

            return CreatedAtRoute("DefaultApi", new { id = vendaViewModel.Id }, vendaViewModel);
        }

        // DELETE: api/Vendas/5
        [ResponseType(typeof(VendaViewModel))]
        public IHttpActionResult DeleteVendaViewModel(Guid id)
        {
            VendaViewModel vendaViewModel =_vendaAppService.BuscarPorId(id);
            if (vendaViewModel == null)
            {
                return NotFound();
            }

            _vendaAppService.Deletar(id);

            return Ok(vendaViewModel);
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