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
    public class Evento_UsuariosController : ApiController
    {
        private SQLContext db = new SQLContext();

        private readonly IEvento_UsuarioAppService _evento_UsuarioAppService = new Evento_UsuarioAppService();

        // GET: api/Evento_UsuarioViewModel
        public IQueryable<Evento_UsuarioViewModel> GetEvento_UsuarioViewModel()
        {
            return _evento_UsuarioAppService.TrazerTodosAtivos().ToList().AsQueryable();
        }

        // GET: api/Evento_UsuarioViewModel/5
        [ResponseType(typeof(Evento_UsuarioViewModel))]
        public IHttpActionResult GetEvento_UsuarioViewModel(Guid id)
        {
            Evento_UsuarioViewModel evento_UsuarioViewModel = _evento_UsuarioAppService.BuscarPorId(id);
            if (evento_UsuarioViewModel == null)
            {
                return NotFound();
            }

            return Ok(evento_UsuarioViewModel);
        }

        // PUT: api/Evento_UsuarioViewModel/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEvento_UsuarioViewModel(Guid id, Evento_UsuarioViewModel evento_UsuarioViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != evento_UsuarioViewModel.Id || !Evento_UsuarioViewModelExists(id))
            {
                return BadRequest();
            }

            _evento_UsuarioAppService.Atualizar(evento_UsuarioViewModel);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Evento_UsuarioViewModel
        [ResponseType(typeof(Evento_UsuarioViewModel))]
        public IHttpActionResult PostEvento_UsuarioViewModel(Evento_UsuarioViewModel evento_UsuarioViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _evento_UsuarioAppService.Criar(evento_UsuarioViewModel);

            return CreatedAtRoute("DefaultApi", new { id = evento_UsuarioViewModel.Id }, evento_UsuarioViewModel);
        }

        // DELETE: api/Evento_UsuarioViewModel/5
        [ResponseType(typeof(Evento_UsuarioViewModel))]
        public IHttpActionResult DeleteEvento_UsuarioViewModel(Guid id)
        {
            Evento_UsuarioViewModel evento_UsuarioViewModel = _evento_UsuarioAppService.BuscarPorId(id);
            if (evento_UsuarioViewModel == null)
            {
                return NotFound();
            }

            _evento_UsuarioAppService.Deletar(id);

            return Ok(evento_UsuarioViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            _evento_UsuarioAppService.Dispose();
            base.Dispose(disposing);
        }

        private bool Evento_UsuarioViewModelExists(Guid? id)
        {
            return db.Evento_Usuarios.Count(e => e.Id == id) > 0;
        }
    }
}