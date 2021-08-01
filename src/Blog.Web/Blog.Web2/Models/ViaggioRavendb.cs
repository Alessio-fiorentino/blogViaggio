using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static Blog.Web2.Models.ViaggioRavendb;

namespace Blog.Web2.Models
{
    public class ViaggioRavendb
    {

             public string Id { get; set; }
            public string Citta { get; set; }

            [DataType(DataType.Date)]
            [Required(ErrorMessage = "Il campo è obbligatorio")]
            public DateTime Periodo { get; set; }
            public string Descrizione { get; set; }
            public string Consigliato { get; set; }
            public string Sconsigliato { get; set; }
        

    }


    public class CittaService
    {
        private readonly IAsyncDocumentSession _session;

        public CittaService(IAsyncDocumentSession dbSession2)
        {
            this._session = dbSession2;
        }

        public async Task<int> GetCittaCount()
        {
            await _session.StoreAsync(new ViaggioRavendb { Citta = "Londra" });
            await _session.SaveChangesAsync();
            return await _session
               .Query<ViaggioRavendb>()
               .CountAsync();
        }

    }
  

}
