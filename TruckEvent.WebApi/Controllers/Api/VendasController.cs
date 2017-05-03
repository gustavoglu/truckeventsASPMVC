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

            _vendaAppService.Criar(vendaViewModel);

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