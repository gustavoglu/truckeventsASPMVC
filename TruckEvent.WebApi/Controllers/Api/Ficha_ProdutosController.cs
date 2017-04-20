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
    public class Ficha_ProdutosController : ApiController
    {
        private SQLContext db = new SQLContext();

        private readonly IFicha_ProdutoAppService _ficha_ProdutoAppService = new Ficha_ProdutoAppService();

        // GET: api/Ficha_Produtos
        public IQueryable<Ficha_ProdutoViewModel> GetFicha_ProdutoViewModel()
        {
            return _ficha_ProdutoAppService.TrazerTodosAtivos().ToList().AsQueryable();
        }

        // GET: api/Ficha_Produtos/5
        [ResponseType(typeof(Ficha_ProdutoViewModel))]
        public IHttpActionResult GetFicha_ProdutoViewModel(Guid id)
        {
            Ficha_ProdutoViewModel ficha_ProdutoViewModel = _ficha_ProdutoAppService.BuscarPorId(id);
            if (ficha_ProdutoViewModel == null)
            {
                return NotFound();
            }

            return Ok(ficha_ProdutoViewModel);
        }

        // PUT: api/Ficha_Produtos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFicha_ProdutoViewModel(Guid id, Ficha_ProdutoViewModel ficha_ProdutoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ficha_ProdutoViewModel.Id)
            {
                return BadRequest();
            }

            _ficha_ProdutoAppService.Atualizar(ficha_ProdutoViewModel);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Ficha_Produtos
        [ResponseType(typeof(Ficha_ProdutoViewModel))]
        public IHttpActionResult PostFicha_ProdutoViewModel(Ficha_ProdutoViewModel ficha_ProdutoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _ficha_ProdutoAppService.Criar(ficha_ProdutoViewModel);

            return CreatedAtRoute("DefaultApi", new { id = ficha_ProdutoViewModel.Id }, ficha_ProdutoViewModel);
        }

        // DELETE: api/Ficha_Produtos/5
        [ResponseType(typeof(Ficha_ProdutoViewModel))]
        public IHttpActionResult DeleteFicha_ProdutoViewModel(Guid id)
        {
            Ficha_ProdutoViewModel ficha_ProdutoViewModel = _ficha_ProdutoAppService.BuscarPorId(id);
            if (ficha_ProdutoViewModel == null)
            {
                return NotFound();
            }
            _ficha_ProdutoAppService.Deletar(id);

            return Ok(ficha_ProdutoViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _ficha_ProdutoAppService.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Ficha_ProdutoViewModelExists(Guid id)
        {
            return db.Ficha_Produtos.Count(e => e.Id == id) > 0;
        }
    }
}