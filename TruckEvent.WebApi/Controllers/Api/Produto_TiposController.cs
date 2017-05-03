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
    public class Produto_TiposController : ApiController
    {
        private SQLContext db = new SQLContext();

        private readonly IProduto_TipoAppService _produto_TipoAppService = new Produto_TipoAppService();

        // GET: api/Produto_Tipos
        public IQueryable<Produto_TipoViewModel> GetProduto_TipoViewModel()
        {
            return _produto_TipoAppService.TrazerTodosAtivos().ToList().AsQueryable();
        }

        // GET: api/Produto_Tipos/5
        [ResponseType(typeof(Produto_TipoViewModel))]
        public IHttpActionResult GetProduto_TipoViewModel(Guid id)
        {
            Produto_TipoViewModel produto_TipoViewModel = _produto_TipoAppService.BuscarPorId(id);
            if (produto_TipoViewModel == null)
            {
                return NotFound();
            }

            return Ok(produto_TipoViewModel);
        }

        // PUT: api/Produto_Tipos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduto_TipoViewModel(Guid id, Produto_TipoViewModel produto_TipoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != produto_TipoViewModel.Id || !Produto_TipoViewModelExists(id))
            {
                return BadRequest();
            }
            _produto_TipoAppService.Atualizar(produto_TipoViewModel);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Produto_Tipos
        [ResponseType(typeof(Produto_TipoViewModel))]
        public IHttpActionResult PostProduto_TipoViewModel(Produto_TipoViewModel produto_TipoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _produto_TipoAppService.Criar(produto_TipoViewModel);
            return CreatedAtRoute("DefaultApi", new { id = produto_TipoViewModel.Id }, produto_TipoViewModel);
        }

        // DELETE: api/Produto_Tipos/5
        [ResponseType(typeof(Produto_TipoViewModel))]
        public IHttpActionResult DeleteProduto_TipoViewModel(Guid id)
        {
            Produto_TipoViewModel produto_TipoViewModel = _produto_TipoAppService.BuscarPorId(id);
            if (produto_TipoViewModel == null)
            {
                return NotFound();
            }

            _produto_TipoAppService.Deletar(id);

            return Ok(produto_TipoViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            _produto_TipoAppService.Dispose();
            base.Dispose(disposing);
        }

        private bool Produto_TipoViewModelExists(Guid? id)
        {
            return db.Produto_Tipos.Count(e => e.Id == id) > 0;
        }
    }
}