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
    public class Pagamento_TiposController : ApiController
    {
        private SQLContext db = new SQLContext();

        private readonly IPagamento_TipoAppService _pagamento_TipoAppService = new Pagamento_TipoAppService();

        // GET: api/Pagamento_TipoViewModel
        public IQueryable<Pagamento_TipoViewModel> GetPagamento_TipoViewModel()
        {
            return _pagamento_TipoAppService.TrazerTodosAtivos().ToList().AsQueryable();
        }

        // GET: api/Pagamento_TipoViewModel/5
        [ResponseType(typeof(Pagamento_TipoViewModel))]
        public IHttpActionResult GetPagamento_TipoViewModel(Guid id)
        {
            Pagamento_TipoViewModel pagamento_TipoViewModel = _pagamento_TipoAppService.BuscarPorId(id);
            if (pagamento_TipoViewModel == null)
            {
                return NotFound();
            }

            return Ok(pagamento_TipoViewModel);
        }

        // PUT: api/Pagamento_TipoViewModel/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPagamento_TipoViewModel(Guid id, Pagamento_TipoViewModel pagamento_TipoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pagamento_TipoViewModel.Id || !Pagamento_TipoViewModelExists(id))
            {
                return BadRequest();
            }
            _pagamento_TipoAppService.Atualizar(pagamento_TipoViewModel);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Pagamento_TipoViewModel
        [ResponseType(typeof(Pagamento_TipoViewModel))]
        public IHttpActionResult PostPagamento_TipoViewModel(Pagamento_TipoViewModel pagamento_TipoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _pagamento_TipoAppService.Criar(pagamento_TipoViewModel);

            return CreatedAtRoute("DefaultApi", new { id = pagamento_TipoViewModel.Id }, pagamento_TipoViewModel);
        }

        // DELETE: api/Pagamento_TipoViewModel/5
        [ResponseType(typeof(Pagamento_TipoViewModel))]
        public IHttpActionResult DeletePagamento_TipoViewModel(Guid id)
        {
            Pagamento_TipoViewModel pagamento_TipoViewModel =_pagamento_TipoAppService.BuscarPorId(id);
            if (pagamento_TipoViewModel == null)
            {
                return NotFound();
            }

            _pagamento_TipoAppService.Deletar(id);

            return Ok(pagamento_TipoViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            _pagamento_TipoAppService.Dispose();
            base.Dispose(disposing);
        }

        private bool Pagamento_TipoViewModelExists(Guid? id)
        {
            return db.Pagamento_Tipos.Count(e => e.Id == id) > 0;
        }
    }
}