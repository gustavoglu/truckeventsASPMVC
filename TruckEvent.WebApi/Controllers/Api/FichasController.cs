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
    public class FichasController : ApiController
    {
        private SQLContext db = new SQLContext();

        private readonly IFichaAppService _fichaAppService = new FichaAppService();

        // GET: api/FichaViewModels
        public IQueryable<FichaViewModel> GetFichaViewModels()
        {
            return _fichaAppService.TrazerTodosAtivos().ToList().AsQueryable();
        }

        // GET: api/FichaViewModels/5
        [ResponseType(typeof(FichaViewModel))]
        public IHttpActionResult GetFichaViewModel(Guid id)
        {
            FichaViewModel fichaViewModel = _fichaAppService.BuscarPorId(id);
            if (fichaViewModel == null)
            {
                return NotFound();
            }

            return Ok(fichaViewModel);
        }

        // PUT: api/FichaViewModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFichaViewModel(Guid id, FichaViewModel fichaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fichaViewModel.Id || !FichaViewModelExists(id))
            {
                return BadRequest();
            }

            _fichaAppService.Atualizar(fichaViewModel);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/FichaViewModels
        [ResponseType(typeof(FichaViewModel))]
        public IHttpActionResult PostFichaViewModel(FichaViewModel fichaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _fichaAppService.Criar(fichaViewModel);

            return CreatedAtRoute("DefaultApi", new { id = fichaViewModel.Id }, fichaViewModel);
        }

        // DELETE: api/FichaViewModels/5
        [ResponseType(typeof(FichaViewModel))]
        public IHttpActionResult DeleteFichaViewModel(Guid id)
        {
            FichaViewModel fichaViewModel =_fichaAppService.BuscarPorId(id);
            if (fichaViewModel == null)
            {
                return NotFound();
            }

            _fichaAppService.Deletar(id);

            return Ok(fichaViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            _fichaAppService.Dispose();
            base.Dispose(disposing);
        }

        private bool FichaViewModelExists(Guid? id)
        {
            return db.Fichas.Count(e => e.Id == id) > 0;
        }
    }
}