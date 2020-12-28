using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ZamowenieController : ApiController
    {

   



        public IEnumerable<Zamowienie> Get()
        {
            using (SMAPIEntities entities = new SMAPIEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.Zamowienie.Include("Towar").ToList();
            }


        }


        public IEnumerable<Zamowienie> Get(int id)
        {
            using (SMAPIEntities entities = new SMAPIEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;

                return entities.Zamowienie.Include("Towar").Where(p => p.FakturaID == id).ToList();
            }


        }







        [HttpPost]
        public IHttpActionResult InsertZam(int id, Zamowienie zam1)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (SMAPIEntities entities = new SMAPIEntities())
            {

                var numerKlienta = entities.Faktura.Where(p => p.FakturaID == id).FirstOrDefault();

                zam1.KlientID = numerKlienta.KlientID;

                zam1.FakturaID = id;

                var poRabacieTemp = zam1.Cena * (100 - zam1.rabat);

                zam1.PoRabacie = poRabacieTemp/100;

                var suma = (zam1.PoRabacie * zam1.ilosc);

                zam1.Razem = suma;

                entities.Zamowienie.Add(zam1);


                entities.SaveChanges();
            }

            return Ok();
        }



  



    }
}
