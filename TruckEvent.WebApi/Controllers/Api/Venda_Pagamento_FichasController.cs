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
    public class Venda_Pagamento_FichasController : ApiController
    {
        private readonly SQLContext db = new SQLContext();
        private readonly IVenda_Pagamento_FichaAppService _venda_Pagamento_FichaAppService = new Venda_Pagamento_FichaAppService();

        // GET: api/Venda_Pagamento_Fichas
        public IQueryable<Venda_Pagamento_FichaViewModel> GetVenda_Pagamento_FichaViewModel()
        {
            return _venda_Pagamento_FichaAppService.TrazerTodosAtivos().AsQueryable();
        }

        // GET: api/Venda_Pagamento_Fichas/5
        [ResponseType(typeof(Venda_Pagamento_FichaViewModel))]
        public IHttpActionResult GetVenda_Pagamento_FichaViewModel(Guid id)
        {
            Venda_Pagamento_FichaViewModel venda_Pagamento_FichaViewModel = _venda_Pagamento_FichaAppService.BuscarPorId(id);
            if (venda_Pagamento_FichaViewModel == null)
            {
                return NotFound();
            }

            return Ok(venda_Pagamento_FichaViewModel);
        }

        // PUT: api/Venda_Pagamento_Fichas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVenda_Pagamento_FichaViewModel(Guid id, Venda_Pagamento_FichaViewModel venda_Pagamento_FichaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != venda_Pagamento_FichaViewModel.Id)
            {
                return BadRequest();
            }

            _venda_Pagamento_FichaAppService.Atualizar(venda_Pagamento_FichaViewModel);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Venda_Pagamento_Fichas
        [ResponseType(typeof(Venda_Pagamento_FichaViewModel))]
        public IHttpActionResult PostVenda_Pagamento_FichaViewModel(Venda_Pagamento_FichaViewModel venda_Pagamento_FichaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _venda_Pagamento_FichaAppService.Criar(venda_Pagamento_FichaViewModel);

            return CreatedAtRoute("DefaultApi", new { id = venda_Pagamento_FichaViewModel.Id }, venda_Pagamento_FichaViewModel);
        }

        // DELETE: api/Venda_Pagamento_Fichas/5
        [ResponseType(typeof(Venda_Pagamento_FichaViewModel))]
        public IHttpActionResult DeleteVenda_Pagamento_FichaViewModel(Guid id)
        {
            Venda_Pagamento_FichaViewModel venda_Pagamento_FichaViewModel = _venda_Pagamento_FichaAppService.BuscarPorId(id);
            if (venda_Pagamento_FichaViewModel == null)
            {
                return NotFound();
            }

            _venda_Pagamento_FichaAppService.Deletar(id);

            return Ok(venda_Pagamento_FichaViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            _venda_Pagamento_FichaAppService.Dispose();
        }

        private bool Venda_Pagamento_FichaViewModelExists(Guid id)
        {
            return db.Venda_Pagamento_Fichas.Count(e => e.Id == id) > 0;
        }
    }
}