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
    public class Usuario_TiposController : ApiController
    {
        private SQLContext db = new SQLContext();

        private readonly IUsuario_TipoAppService _usuario_TipoAppService = new Usuario_TipoAppService();

        // GET: api/Usuario_Tipos
        public IQueryable<Usuario_TipoViewModel> GetUsuario_TipoViewModel()
        {
            return _usuario_TipoAppService.TrazerTodosAtivos().ToList().AsQueryable();
        }

        // GET: api/Usuario_Tipos/5
        [ResponseType(typeof(Usuario_TipoViewModel))]
        public IHttpActionResult GetUsuario_TipoViewModel(Guid id)
        {
            Usuario_TipoViewModel usuario_TipoViewModel = _usuario_TipoAppService.BuscarPorId(id);
            if (usuario_TipoViewModel == null)
            {
                return NotFound();
            }

            return Ok(usuario_TipoViewModel);
        }

        // PUT: api/Usuario_Tipos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsuario_TipoViewModel(Guid id, Usuario_TipoViewModel usuario_TipoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuario_TipoViewModel.Id)
            {
                return BadRequest();
            }

            _usuario_TipoAppService.Atualizar(usuario_TipoViewModel);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Usuario_Tipos
        [ResponseType(typeof(Usuario_TipoViewModel))]
        public IHttpActionResult PostUsuario_TipoViewModel(Usuario_TipoViewModel usuario_TipoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _usuario_TipoAppService.Criar(usuario_TipoViewModel);
            return CreatedAtRoute("DefaultApi", new { id = usuario_TipoViewModel.Id }, usuario_TipoViewModel);
        }

        // DELETE: api/Usuario_Tipos/5
        [ResponseType(typeof(Usuario_TipoViewModel))]
        public IHttpActionResult DeleteUsuario_TipoViewModel(Guid id)
        {
            Usuario_TipoViewModel usuario_TipoViewModel = _usuario_TipoAppService.BuscarPorId(id);
            if (usuario_TipoViewModel == null)
            {
                return NotFound();
            }

            _usuario_TipoAppService.Deletar(id);

            return Ok(usuario_TipoViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            _usuario_TipoAppService.Dispose();
            base.Dispose(disposing);
        }

        private bool Usuario_TipoViewModelExists(Guid? id)
        {
            return db.Usuario_Tipos.Count(e => e.Id == id) > 0;
        }
    }
}