using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using TruckEvent.WebApi.Infra;
using TruckEvent.WebApi.Services;
using TruckEvent.WebApi.Services.Interfaces;
using TruckEvent.WebApi.ViewModels;

namespace TruckEvent.WebApi.Controllers.Api
{
    public class EventosController : ApiController
    {
        private SQLContext db = new SQLContext();

        private readonly IEventoAppService _eventoAppService = new EventoAppService();

        // GET: api/EventoViewModels
        public IQueryable<EventoViewModel> GetEventoViewModels()
        {
            return _eventoAppService.TrazerTodosAtivos().ToList().AsQueryable();
        }

        // GET: api/EventoViewModels/5
        [ResponseType(typeof(EventoViewModel))]
        public IHttpActionResult GetEventoViewModel(Guid id)
        {
            EventoViewModel eventoViewModel = _eventoAppService.BuscarPorId(id);
            if (eventoViewModel == null)
            {
                return NotFound();
            }

            return Ok(eventoViewModel);
        }

        // PUT: api/EventoViewModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEventoViewModel(Guid id, EventoViewModel eventoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventoViewModel.Id)
            {
                return BadRequest();
            }
            _eventoAppService.Atualizar(eventoViewModel);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/EventoViewModels
        [ResponseType(typeof(EventoViewModel))]
        public IHttpActionResult PostEventoViewModel(EventoViewModel eventoViewModel)
        {

            var usuario = db.Users.SingleOrDefault(u => u.UserName == HttpContext.Current.User.Identity.Name);
            if (usuario == null)
            {
                return BadRequest("Nenhum Usuario Logado");
            }

            if (usuario.Organizador == false)
            {
                return BadRequest("É Necessário ser um Organizador para criar um Evento");
            }

            // eventoViewModel.Id_usuario_organizador = usuario.Id;
            eventoViewModel.Id_organizador = usuario.Id;//Mapper.Map<UsuarioViewModel> (usuario);
            ;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _eventoAppService.Criar(eventoViewModel);

            return CreatedAtRoute("DefaultApi", new { id = eventoViewModel.Id }, eventoViewModel);
        }

        // DELETE: api/EventoViewModels/5
        [ResponseType(typeof(EventoViewModel))]
        public IHttpActionResult DeleteEventoViewModel(Guid id)
        {
            EventoViewModel eventoViewModel = _eventoAppService.BuscarPorId(id);
            if (eventoViewModel == null)
            {
                return NotFound();
            }

            return Ok(eventoViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            _eventoAppService.Dispose();
            base.Dispose(disposing);
        }

        private bool EventoViewModelExists(Guid? id)
        {
            return db.Eventos.Count(e => e.Id == id) > 0;
        }
    }
}