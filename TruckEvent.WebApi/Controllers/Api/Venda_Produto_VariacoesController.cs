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
    public class Venda_Produto_VariacoesController : ApiController
    {
        private SQLContext db = new SQLContext();

        private readonly IVenda_Produto_VariacaoAppService _venda_Produto_VariacaoAppService = new Venda_Produto_VariacaoAppService();

        // GET: api/Venda_Produto_Variacoes
        public IQueryable<Venda_Produto_VariacaoViewModel> GetVenda_Produto_VariacaoViewModel()
        {
            return _venda_Produto_VariacaoAppService.TrazerTodosAtivos().ToList().AsQueryable();
        }

        // GET: api/Venda_Produto_Variacoes/5
        [ResponseType(typeof(Venda_Produto_VariacaoViewModel))]
        public IHttpActionResult GetVenda_Produto_VariacaoViewModel(Guid id)
        {
            Venda_Produto_VariacaoViewModel venda_Produto_VariacaoViewModel =_venda_Produto_VariacaoAppService.BuscarPorId(id);
            if (venda_Produto_VariacaoViewModel == null)
            {
                return NotFound();
            }

            return Ok(venda_Produto_VariacaoViewModel);
        }

        // PUT: api/Venda_Produto_Variacoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVenda_Produto_VariacaoViewModel(Guid id, Venda_Produto_VariacaoViewModel venda_Produto_VariacaoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != venda_Produto_VariacaoViewModel.Id)
            {
                return BadRequest();
            }

            _venda_Produto_VariacaoAppService.Atualizar(venda_Produto_VariacaoViewModel);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Venda_Produto_Variacoes
        [ResponseType(typeof(Venda_Produto_VariacaoViewModel))]
        public IHttpActionResult PostVenda_Produto_VariacaoViewModel(Venda_Produto_VariacaoViewModel venda_Produto_VariacaoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _venda_Produto_VariacaoAppService.Criar(venda_Produto_VariacaoViewModel);

            return CreatedAtRoute("DefaultApi", new { id = venda_Produto_VariacaoViewModel.Id }, venda_Produto_VariacaoViewModel);
        }

        // DELETE: api/Venda_Produto_Variacoes/5
        [ResponseType(typeof(Venda_Produto_VariacaoViewModel))]
        public IHttpActionResult DeleteVenda_Produto_VariacaoViewModel(Guid id)
        {
            Venda_Produto_VariacaoViewModel venda_Produto_VariacaoViewModel = _venda_Produto_VariacaoAppService.BuscarPorId(id);
            if (venda_Produto_VariacaoViewModel == null)
            {
                return NotFound();
            }

            _venda_Produto_VariacaoAppService.Deletar(id);

            return Ok(venda_Produto_VariacaoViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            _venda_Produto_VariacaoAppService.Dispose();
            base.Dispose(disposing);
        }

        private bool Venda_Produto_VariacaoViewModelExists(Guid? id)
        {
            return db.Venda_Produto_Variacoes.Count(e => e.Id == id) > 0;
        }
    }
}