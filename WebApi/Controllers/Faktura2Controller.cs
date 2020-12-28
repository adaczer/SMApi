using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class Faktura2Controller : ApiController
    {
      


        public IEnumerable<Faktura> Get()
        {
            using (SMAPIEntities entities = new SMAPIEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.Faktura.Include("Klient").ToList();
            }


        }

        public Faktura Get(int id)
        {
            using (SMAPIEntities entities = new SMAPIEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.Faktura.Include("Klient").FirstOrDefault(e => e.FakturaID == id);
            }


        }


        public Faktura Get(string nazwa)
        {
            using (SMAPIEntities entities = new SMAPIEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.Faktura.Include("Klient").FirstOrDefault(e => e.Klient.nazwaKlienta == nazwa);
            }


        }


        [HttpPost]
        public IHttpActionResult InsertFakt(Faktura faktura1)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (SMAPIEntities entities = new SMAPIEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;

                var ostatni = entities.Faktura.Max(p => p.FakturaID);

                faktura1.NrFaktury = ostatni + 1 + "/2020";

                faktura1.Klient.numerKlienta = "QWE" + (ostatni+1).ToString();

                entities.Faktura.Add(faktura1);

                entities.SaveChanges();

                


            }

            return Ok(faktura1);
        }



        //public IHttpActionResult GetFakId(int id)
        //{
        //    using (SMAPIEntities entities = new SMAPIEntities())
        //    {
        //        Faktura fakturaDetails = null;
        //        fakturaDetails = entities.Faktura.Where(x => x.FakturaID == id).Select(x => new Faktura()
        //        {
        //            FakturaID = x.FakturaID,
        //            NrFaktury = x.NrFaktury,
        //            KlientID = x.KlientID,
        //            wartosc = x.wartosc,
        //            Data = x.Data
        //        }).FirstOrDefault<Faktura>();
        //        if (fakturaDetails==null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(fakturaDetails);
        //    }

        //}


        //public Towary Get(int id)
        //{
        //    using (TowaryAPIEntities entities = new TowaryAPIEntities())
        //    {
        //        return entities.Towary.FirstOrDefault(e => e.ID == id);
        //    }

        //}



    }
}
