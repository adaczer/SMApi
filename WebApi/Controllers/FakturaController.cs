using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using WebApi.Models;

namespace WebApi.Controllers
{
    /*
    Aby można było dodać trasę dla tego kontrolera, klasa WebApiConfig może wymagać dodatkowych zmian. Dołącz te instrukcje do metody Register klasy WebApiConfig. W adresach URL OData jest uwzględniana wielkość liter.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using WebApi.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Faktura>("Faktura");
    builder.EntitySet<Klient>("Klient"); 
    builder.EntitySet<Zamowienie>("Zamowienie"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class FakturaController : ODataController
    {
        private SMAPIEntities db = new SMAPIEntities();

        // GET: odata/Faktura
        [EnableQuery]
       // public IQueryable<Faktura> GetFaktura()
            public IEnumerable<Faktura> GetFaktura()
        {
            return db.Faktura.ToList();
        }

        // GET: odata/Faktura(5)
        [EnableQuery]
        public SingleResult<Faktura> GetFaktura([FromODataUri] int key)
        {
            return SingleResult.Create(db.Faktura.Where(faktura => faktura.FakturaID == key));
        }

        // PUT: odata/Faktura(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Faktura> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Faktura faktura = db.Faktura.Find(key);
            if (faktura == null)
            {
                return NotFound();
            }

            patch.Put(faktura);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FakturaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(faktura);
        }

        // POST: odata/Faktura
        public IHttpActionResult Post(Faktura faktura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Faktura.Add(faktura);
            db.SaveChanges();

            return Created(faktura);
        }

        // PATCH: odata/Faktura(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Faktura> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Faktura faktura = db.Faktura.Find(key);
            if (faktura == null)
            {
                return NotFound();
            }

            patch.Patch(faktura);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FakturaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(faktura);
        }

        // DELETE: odata/Faktura(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Faktura faktura = db.Faktura.Find(key);
            if (faktura == null)
            {
                return NotFound();
            }

            db.Faktura.Remove(faktura);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Faktura(5)/Klient
        [EnableQuery]
        public SingleResult<Klient> GetKlient([FromODataUri] int key)
        {
            return SingleResult.Create(db.Faktura.Where(m => m.FakturaID == key).Select(m => m.Klient));
        }

        // GET: odata/Faktura(5)/Zamowienie
        [EnableQuery]
        public IQueryable<Zamowienie> GetZamowienie([FromODataUri] int key)
        {
            return db.Faktura.Where(m => m.FakturaID == key).SelectMany(m => m.Zamowienie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FakturaExists(int key)
        {
            return db.Faktura.Count(e => e.FakturaID == key) > 0;
        }
    }
}
