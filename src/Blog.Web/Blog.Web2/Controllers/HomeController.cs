using Blog.Web2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Raven.Client.Documents;
using Raven.Client.Documents.Linq;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using System.Linq;
using System.Threading.Tasks;
using System.Web;

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
    
        public async Task<IActionResult> Cerca (string currentFilter,string searchString,int? pageNumber,int? pageSize,int? pageCurrent)
        {
            
            IRavenQueryable<ViaggioRavendb> TutteLeCitta = from m in _session.Query<ViaggioRavendb>()
                                                        select m;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;

            

            if (!String.IsNullOrEmpty(searchString))
            {

                TutteLeCitta = from viaggio in _session.Query<ViaggioRavendb>()
                               where viaggio.Citta.StartsWith(searchString)
                               select viaggio;
             }

            if (pageSize != null)
            {
                pageNumber = 1;
            }
            else
            {
                pageSize = pageCurrent;
            }
            ViewData["CurrentPage"]=pageSize;

            
            return View(await PaginatedList<ViaggioRavendb>.CreateAsync(TutteLeCitta, pageNumber ?? 1, pageSize ?? 5));
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
                return RedirectToAction(nameof(Cerca));
            }
            return View(ravendb);
        }
       
        public async Task<IActionResult> Visualizza(String id)
        {

            var idD = id.UrlDecode();
         
            if (id == null)
            {
                return NotFound();
            }
           


            IRavenQueryable<ViaggioRavendb> query = from viaggio in _session.Query<ViaggioRavendb>()
                                             where viaggio.Id == idD
                                                    select viaggio;

            List<ViaggioRavendb> viaggi = await query.ToListAsync();

      
            
                if (id == null)
                {
                    return NotFound();
                }

            return View(viaggi[0]);




        }
        
      
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        

    }
}
