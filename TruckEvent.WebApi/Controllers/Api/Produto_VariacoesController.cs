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
    public class Produto_VariacoesController : ApiController
    {
        private SQLContext db = new SQLContext();

        private readonly IProduto_VariacaoAppService _produto_VariacaoAppService = new Produto_VariacaoAppService();

        // GET: api/Produto_Variacoes
        public IQueryable<Produto_VariacaoViewModel> GetProduto_VariacaoViewModel()
        {
            return _produto_VariacaoAppService.TrazerTodosAtivos().ToList().AsQueryable();
        }

        // GET: api/Produto_Variacoes/5
        [ResponseType(typeof(Produto_VariacaoViewModel))]
        public IHttpActionResult GetProduto_VariacaoViewModel(Guid id)
        {
            Produto_VariacaoViewModel produto_VariacaoViewModel = _produto_VariacaoAppService.BuscarPorId(id);
            if (produto_VariacaoViewModel == null)
            {
                return NotFound();
            }

            return Ok(produto_VariacaoViewModel);
        }

        // PUT: api/Produto_Variacoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduto_VariacaoViewModel(Guid id, Produto_VariacaoViewModel produto_VariacaoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != produto_VariacaoViewModel.Id || !Produto_VariacaoViewModelExists(id))
            {
                return BadRequest();
            }
            _produto_VariacaoAppService.Atualizar(produto_VariacaoViewModel);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Produto_Variacoes
        [ResponseType(typeof(Produto_VariacaoViewModel))]
        public IHttpActionResult PostProduto_VariacaoViewModel(Produto_VariacaoViewModel produto_VariacaoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

          
            _produto_VariacaoAppService.Criar(produto_VariacaoViewModel);

            return CreatedAtRoute("DefaultApi", new { id = produto_VariacaoViewModel.Id }, produto_VariacaoViewModel);
        }

        // DELETE: api/Produto_Variacoes/5
        [ResponseType(typeof(Produto_VariacaoViewModel))]
        public IHttpActionResult DeleteProduto_VariacaoViewModel(Guid id)
        {
            Produto_VariacaoViewModel produto_VariacaoViewModel =_produto_VariacaoAppService.BuscarPorId(id);
            if (produto_VariacaoViewModel == null)
            {
                return NotFound();
            }

            _produto_VariacaoAppService.Deletar(id);

            return Ok(produto_VariacaoViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            _produto_VariacaoAppService.Dispose();
            base.Dispose(disposing);
        }

        private bool Produto_VariacaoViewModelExists(Guid? id)
        {
            return db.Produto_Variacoes.Count(e => e.Id == id) > 0;
        }
    }
}