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
    public class ConsequenciasController : ApiController
    {
        private readonly SQLContext db = new SQLContext();

        private readonly IConsequenciaAppService _consequenciaAppService = new ConsequenciaAppService();

        // GET: api/ConsequenciaViewModels
        public IQueryable<ConsequenciaViewModel> GetConsequenciaViewModels()
        {
            return _consequenciaAppService.TrazerTodosAtivos().ToList().AsQueryable();
        }

        // GET: api/ConsequenciaViewModels/5
        [ResponseType(typeof(ConsequenciaViewModel))]
        public IHttpActionResult GetConsequenciaViewModel(Guid id)
        {
            ConsequenciaViewModel consequenciaViewModel =_consequenciaAppService.BuscarPorId(id);
            if (consequenciaViewModel == null)
            {
                return NotFound();
            }

            return Ok(consequenciaViewModel);
        }

        // PUT: api/ConsequenciaViewModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutConsequenciaViewModel(Guid id, ConsequenciaViewModel consequenciaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != consequenciaViewModel.Id)
            {
                return BadRequest();
            }

            _consequenciaAppService.Atualizar(consequenciaViewModel);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ConsequenciaViewModels
        [ResponseType(typeof(ConsequenciaViewModel))]
        public IHttpActionResult PostConsequenciaViewModel(ConsequenciaViewModel consequenciaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _consequenciaAppService.Criar(consequenciaViewModel);

            return CreatedAtRoute("DefaultApi", new { id = consequenciaViewModel.Id }, consequenciaViewModel);
        }

        // DELETE: api/ConsequenciaViewModels/5
        [ResponseType(typeof(ConsequenciaViewModel))]
        public IHttpActionResult DeleteConsequenciaViewModel(Guid id)
        {
            ConsequenciaViewModel consequenciaViewModel = _consequenciaAppService.BuscarPorId(id);
            if (consequenciaViewModel == null)
            {
                return NotFound();
            }

            _consequenciaAppService.Deletar(id);

            return Ok(consequenciaViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            _consequenciaAppService.Dispose();
            base.Dispose(disposing);
        }

        private bool ConsequenciaViewModelExists(Guid? id)
        {
            return db.Consequencias.Count(e => e.Id == id) > 0;
        }
    }
}