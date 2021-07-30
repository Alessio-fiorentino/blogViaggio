using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Blog.Web2.Models.ravendb;

namespace Blog.Web2.Models
{
    public class ravendb
    {
        public class Viaggio
        {
            public string Citta { get; set; }
            public string Periodo { get; set; }
            public string Descrizione { get; set; }
        }

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
            await _session.StoreAsync(new Viaggio { Citta = "Londra" });
            await _session.SaveChangesAsync();
            return await _session
               .Query<Viaggio>()
               .CountAsync();
        }

    }
}
