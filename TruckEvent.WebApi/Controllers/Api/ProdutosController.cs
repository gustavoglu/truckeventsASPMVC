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
    public class ProdutosController : ApiController
    {
        private SQLContext db = new SQLContext();

        private readonly IProdutoAppService _produtoAppService = new ProdutoAppService();

        // GET: api/Produtos
        public IQueryable<ProdutoViewModel> GetProdutoViewModels()
        {
            return _produtoAppService.TrazerTodosAtivos().ToList().AsQueryable();
        }

        // GET: api/Produtos/5
        [ResponseType(typeof(ProdutoViewModel))]
        public IHttpActionResult GetProdutoViewModel(Guid id)
        {
            ProdutoViewModel produtoViewModel = _produtoAppService.BuscarPorId(id);
            if (produtoViewModel == null)
            {
                return NotFound();
            }

            return Ok(produtoViewModel);
        }

        // PUT: api/Produtos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProdutoViewModel(Guid id, ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != produtoViewModel.Id || !ProdutoViewModelExists(id))
            {
                return BadRequest();
            }
            _produtoAppService.Atualizar(produtoViewModel);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Produtos
        [ResponseType(typeof(ProdutoViewModel))]
        public IHttpActionResult PostProdutoViewModel(ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _produtoAppService.Criar(produtoViewModel);

            return CreatedAtRoute("DefaultApi", new { id = produtoViewModel.Id }, produtoViewModel);
        }

        // DELETE: api/Produtos/5
        [ResponseType(typeof(ProdutoViewModel))]
        public IHttpActionResult DeleteProdutoViewModel(Guid id)
        {
            ProdutoViewModel produtoViewModel = _produtoAppService.BuscarPorId(id);
            if (produtoViewModel == null)
            {
                return NotFound();
            }

            _produtoAppService.Deletar(id);

            return Ok(produtoViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            _produtoAppService.Dispose();
            base.Dispose(disposing);
        }

        private bool ProdutoViewModelExists(Guid? id)
        {
            return db.Produtos.Count(e => e.Id == id) > 0;
        }
    }
}