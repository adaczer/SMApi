using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using MVC.Models;


namespace MVC.Controllers
{
    public class ZamowieniaController : Controller
    {
    



        public ActionResult Index()
        {
            IEnumerable<mvcZamowienie> zam1 = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:56214/api/");

                var responseTask = client.GetAsync("Zamowenie");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<mvcZamowienie>>();

                    readTask.Wait();

                    zam1 = readTask.Result;
                }
                else //web api sent error response 
                {
                    zam1 = Enumerable.Empty<mvcZamowienie>();
                }

                return View(zam1);

            }
        }





        public ActionResult DetailsList(int id)
        {
            IEnumerable<mvcZamowienie> zamLista = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:56214/api/Zamowenie");

                var responseTask = client.GetAsync("Zamowenie?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<mvcZamowienie>>();

                    readTask.Wait();

                    zamLista = readTask.Result;
                }
                else 
                {
                    // faktura1 = Empty<mvcFaktura>();
                }

                ViewBag.faktura = id;

                TempData["nr"] = id;


                return View(zamLista);

            }
        }









        public ActionResult Create()
        {


            return View();
        }





        //metoda ktora dodaje do faktury towary , przyjmuje parametr, 
        // na ktorego podstawie przypisane produkty sa do danej faktury
        [HttpPost]
        public ActionResult Create(int id, mvcZamowienie insertZam)
        {


            var nr = id;

            using (var client = new HttpClient())
            {
                ViewData["nr"] = nr;

                client.BaseAddress = new Uri("http://localhost:56214/api/Zamowenie");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<mvcZamowienie>("Zamowenie?id=" + id.ToString(), insertZam);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("DetailsList", "Zamowienia", new { id = nr});
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(insertZam);
        }









    }
}