using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using TruckEvent.WebApi.Infra;
using TruckEvent.WebApi.ViewModels;

namespace TruckEvent.WebApi.Controllers.Api
{
    public class UsuariosController : ApiController
    {
        private SQLContext db = new SQLContext();


        [HttpGet]
        public string Get()
        {
            var identityClaim = (ClaimsPrincipal)Thread.CurrentPrincipal;

            return identityClaim.Claims.SingleOrDefault(c => c.Type == "id_usuario").Value;

        }

        // GET: api/Usuarios
        //public IQueryable<UsuarioViewModel> GetUsuarioViewModels()
        //{
        //    return db.UsuarioViewModels;
        //}

        //// GET: api/Usuarios/5
        //[ResponseType(typeof(UsuarioViewModel))]
        //public IHttpActionResult GetUsuarioViewModel(string id)
        //{
        //    UsuarioViewModel usuarioViewModel = db.UsuarioViewModels.Find(id);
        //    if (usuarioViewModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(usuarioViewModel);
        //}

        //// PUT: api/Usuarios/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutUsuarioViewModel(string id, UsuarioViewModel usuarioViewModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != usuarioViewModel.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(usuarioViewModel).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UsuarioViewModelExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Usuarios
        //[ResponseType(typeof(UsuarioViewModel))]
        //public IHttpActionResult PostUsuarioViewModel(UsuarioViewModel usuarioViewModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.UsuarioViewModels.Add(usuarioViewModel);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (UsuarioViewModelExists(usuarioViewModel.Id))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = usuarioViewModel.Id }, usuarioViewModel);
        //}

        //// DELETE: api/Usuarios/5
        //[ResponseType(typeof(UsuarioViewModel))]
        //public IHttpActionResult DeleteUsuarioViewModel(string id)
        //{
        //    UsuarioViewModel usuarioViewModel = db.UsuarioViewModels.Find(id);
        //    if (usuarioViewModel == null)
        //    {
        //        return NotFound();
        //    }

        //    db.UsuarioViewModels.Remove(usuarioViewModel);
        //    db.SaveChanges();

        //    return Ok(usuarioViewModel);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool UsuarioViewModelExists(string id)
        //{
        //    return db.UsuarioViewModels.Count(e => e.Id == id) > 0;
        //}
    }
}