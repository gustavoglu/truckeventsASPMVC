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
    public class Produto_CoresController : ApiController
    {
        private SQLContext db = new SQLContext();

        private readonly IProduto_CorAppService _produto_CorAppService = new Produto_CorAppService();

        // GET: api/Produto_Cores
        public IQueryable<Produto_CorViewModel> GetProduto_CorViewModel()
        {
            return _produto_CorAppService.TrazerTodosAtivos().ToList().AsQueryable();
        }

        // GET: api/Produto_Cores/5
        [ResponseType(typeof(Produto_CorViewModel))]
        public IHttpActionResult GetProduto_CorViewModel(Guid id)
        {
            Produto_CorViewModel produto_CorViewModel =_produto_CorAppService.BuscarPorId(id);
            if (produto_CorViewModel == null)
            {
                return NotFound();
            }

            return Ok(produto_CorViewModel);
        }

        // PUT: api/Produto_Cores/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduto_CorViewModel(Guid id, Produto_CorViewModel produto_CorViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != produto_CorViewModel.Id || !Produto_CorViewModelExists(id))
            {
                return BadRequest();
            }

            _produto_CorAppService.Atualizar(produto_CorViewModel);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Produto_Cores
        [ResponseType(typeof(Produto_CorViewModel))]
        public IHttpActionResult PostProduto_CorViewModel(Produto_CorViewModel produto_CorViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _produto_CorAppService.Criar(produto_CorViewModel);

            return CreatedAtRoute("DefaultApi", new { id = produto_CorViewModel.Id }, produto_CorViewModel);
        }

        // DELETE: api/Produto_Cores/5
        [ResponseType(typeof(Produto_CorViewModel))]
        public IHttpActionResult DeleteProduto_CorViewModel(Guid id)
        {
            Produto_CorViewModel produto_CorViewModel = _produto_CorAppService.BuscarPorId(id);
            if (produto_CorViewModel == null)
            {
                return NotFound();
            }

            _produto_CorAppService.Deletar(id);

            return Ok(produto_CorViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            _produto_CorAppService.Dispose();
            base.Dispose(disposing);
        }

        private bool Produto_CorViewModelExists(Guid? id)
        {
            return db.Produto_Cores.Count(e => e.Id == id) > 0;
        }
    }
}