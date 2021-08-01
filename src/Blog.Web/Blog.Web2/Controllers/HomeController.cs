using Blog.Web2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using static Blog.Web2.Models.IndexViewModel;
using static Blog.Web2.Models.ViaggioRavendb;

namespace Blog.Web2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAsyncDocumentSession _session;

        public HomeController(IAsyncDocumentSession dbSession2)
        {
            this._session = dbSession2;
        }

        public IActionResult Index()
        {
            var model = new ViaggioRavendb();


            return View(model);
        }

        public ViewResult Cerca (string searchString)
        {

         
                var model =  _session.Query<ViaggioRavendb>()
                .Where(i => i.Citta.Contains(searchString))
                .OrderByDescending(i => i.Periodo)
                .ToList();
                return View(model);
            
        }
        public IActionResult CreateRaven()
        {
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> CreateRaven([Bind("Id,Citta,Periodo,Descrizione,Consigliato,Sconsigliato")] ViaggioRavendb ravendb) {

            if (ModelState.IsValid)
            {
                await _session.StoreAsync(ravendb);
                await _session.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ravendb);
        }
        public async Task<IActionResult> Visualizza(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visualizza = await _session.LoadAsync<ViaggioRavendb>(id);
            if (visualizza == null)
            {
                return NotFound();
            }
            return View(visualizza);
        }
        public IActionResult Privacy()
        {
            var modelRaven = new ViaggioRavendb();
            return View(modelRaven);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
    }
}
