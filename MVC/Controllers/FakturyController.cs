using MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    [RoutePrefix("Home")]
    public class FakturyController : Controller
    {
        // GET: Faktury
        public ActionResult Index()
        {
            return View();
        }



        // akcja zaciągająca z api wszyskie faktury, zwraca w returnie liste do widoku.


        [Route("Przegladaj")]
        public ActionResult Index22()
        {
            IEnumerable<mvcFaktura> towars = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:56214/api/");

                var responseTask = client.GetAsync("Faktura2");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                   // var readTask = result.Content.ReadAsAsync<IList<mvcFaktura>>();

                    var readTask = result.Content.ReadAsAsync<IEnumerable<mvcFaktura>>();

                 //   mvcFaktura datalist = JsonConvert.DeserializeObject<mvcFaktura>(jsonstring);

                    readTask.Wait();

                    towars = readTask.Result;
                }
                else //web api sent error response 
                {
                    towars = Enumerable.Empty<mvcFaktura>();
                }

                return View(towars);

            }
        }







        public ActionResult Details(int id)
        {
            mvcFaktura faktura1 = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:56214/api/");

                var responseTask = client.GetAsync("Faktura2?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    // var readTask = result.Content.ReadAsAsync<IList<mvcFaktura>>();

                    var readTask = result.Content.ReadAsAsync<mvcFaktura>();

                    //   mvcFaktura datalist = JsonConvert.DeserializeObject<mvcFaktura>(jsonstring);

                    readTask.Wait();

                    faktura1 = readTask.Result;
                }
                else //web api sent error response 
                {
                   // faktura1 = Empty<mvcFaktura>();
                }

                return View(faktura1);

            }
        }




        public ActionResult Create()
        {
            return View();
        }


        // metoda rozpoczynajaca tworzenie faktury, napierw uzupelniany jest model danych dla Faktury,
        // nastepnie Redirect do metody .. w ktorej uzupelniamy towary ktore zamowiono.
        [HttpPost]
        public ActionResult Create(mvcFaktura insertFak)
        {

            mvcFaktura spowrotem = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:56214/api/Faktura2");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<mvcFaktura>("Faktura2", insertFak);
                postTask.Wait();

                //HTTP GET
                //string nazwa = insertFak.Klient.nazwaKlienta;

                //var responseTask = client.GetAsync("Faktura2");
                //responseTask.Wait();

                //var result2 = responseTask.Result;


                var result = postTask.Result;
                
                if (result.IsSuccessStatusCode)
                {
                    //var readTask = result2.Content.ReadAsAsync<IList<mvcFaktura>>();
                    //readTask.Wait();
                    var displayData = result.Content.ReadAsAsync<mvcFaktura>();
                    displayData.Wait();
                    spowrotem = displayData.Result;


                    return RedirectToAction("DetailsList", "Zamowienia", new { id = spowrotem.FakturaID });
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(insertFak);
        }





    }
}