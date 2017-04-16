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
    public class Venda_ProdutosController : ApiController
    {
        private SQLContext db = new SQLContext();

        private readonly IVenda_ProdutoAppService _venda_ProdutoAppService = new Venda_ProdutoAppService();

        // GET: api/Venda_Produtos
        public IQueryable<Venda_ProdutoViewModel> GetVenda_ProdutoViewModel()
        {
            return _venda_ProdutoAppService.TrazerTodosAtivos().ToList().AsQueryable();
        }

        // GET: api/Venda_Produtos/5
        [ResponseType(typeof(Venda_ProdutoViewModel))]
        public IHttpActionResult GetVenda_ProdutoViewModel(Guid id)
        {
            Venda_ProdutoViewModel venda_ProdutoViewModel = _venda_ProdutoAppService.BuscarPorId(id);
            if (venda_ProdutoViewModel == null)
            {
                return NotFound();
            }

            return Ok(venda_ProdutoViewModel);
        }

        // PUT: api/Venda_Produtos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVenda_ProdutoViewModel(Guid id, Venda_ProdutoViewModel venda_ProdutoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != venda_ProdutoViewModel.Id)
            {
                return BadRequest();
            }
            _venda_ProdutoAppService.Atualizar(venda_ProdutoViewModel);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Venda_Produtos
        [ResponseType(typeof(Venda_ProdutoViewModel))]
        public IHttpActionResult PostVenda_ProdutoViewModel(Venda_ProdutoViewModel venda_ProdutoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _venda_ProdutoAppService.Criar(venda_ProdutoViewModel);

            return CreatedAtRoute("DefaultApi", new { id = venda_ProdutoViewModel.Id }, venda_ProdutoViewModel);
        }

        // DELETE: api/Venda_Produtos/5
        [ResponseType(typeof(Venda_ProdutoViewModel))]
        public IHttpActionResult DeleteVenda_ProdutoViewModel(Guid id)
        {
            Venda_ProdutoViewModel venda_ProdutoViewModel =_venda_ProdutoAppService.BuscarPorId(id);
            if (venda_ProdutoViewModel == null)
            {
                return NotFound();
            }

            _venda_ProdutoAppService.Deletar(id);

            return Ok(venda_ProdutoViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            _venda_ProdutoAppService.Dispose();
            base.Dispose(disposing);
        }

        private bool Venda_ProdutoViewModelExists(Guid? id)
        {
            return db.Venda_Produtos.Count(e => e.Id == id) > 0;
        }
    }
}