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
    public class Venda_PagamentosController : ApiController
    {
        private SQLContext db = new SQLContext();

        private readonly IVenda_PagamentoAppService _venda_PagamentoAppService = new Venda_PagamentoAppService();

        // GET: api/Venda_Pagamentosl
        public IQueryable<Venda_PagamentoViewModel> GetVenda_PagamentoViewModel()
        {
            return _venda_PagamentoAppService.TrazerTodosAtivos().ToList().AsQueryable();
        }

        // GET: api/Venda_Pagamentosl/5
        [ResponseType(typeof(Venda_PagamentoViewModel))]
        public IHttpActionResult GetVenda_PagamentoViewModel(Guid id)
        {
            Venda_PagamentoViewModel venda_PagamentoViewModel = _venda_PagamentoAppService.BuscarPorId(id);
            if (venda_PagamentoViewModel == null)
            {
                return NotFound();
            }

            return Ok(venda_PagamentoViewModel);
        }

        // PUT: api/Venda_Pagamentosl/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVenda_PagamentoViewModel(Guid id, Venda_PagamentoViewModel venda_PagamentoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != venda_PagamentoViewModel.Id || !Venda_PagamentoViewModelExists(id))
            {
                return BadRequest();
            }

            _venda_PagamentoAppService.Atualizar(venda_PagamentoViewModel);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Venda_Pagamentosl
        [ResponseType(typeof(Venda_PagamentoViewModel))]
        public IHttpActionResult PostVenda_PagamentoViewModel(Venda_PagamentoViewModel venda_PagamentoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _venda_PagamentoAppService.Criar(venda_PagamentoViewModel);

            return CreatedAtRoute("DefaultApi", new { id = venda_PagamentoViewModel.Id }, venda_PagamentoViewModel);
        }

        // DELETE: api/Venda_Pagamentosl/5
        [ResponseType(typeof(Venda_PagamentoViewModel))]
        public IHttpActionResult DeleteVenda_PagamentoViewModel(Guid id)
        {
            Venda_PagamentoViewModel venda_PagamentoViewModel = _venda_PagamentoAppService.BuscarPorId(id);
            if (venda_PagamentoViewModel == null)
            {
                return NotFound();
            }
            _venda_PagamentoAppService.Deletar(id);
            return Ok(venda_PagamentoViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            _venda_PagamentoAppService.Dispose();
            base.Dispose(disposing);
        }

        private bool Venda_PagamentoViewModelExists(Guid? id)
        {
            return db.Venda_Pagamentos.Count(e => e.Id == id) > 0;
        }
    }
}