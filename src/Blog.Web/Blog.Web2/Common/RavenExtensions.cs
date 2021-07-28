﻿using Raven.Client.Documents;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Blog.Web2.Models.IndexViewModel;

namespace Common
{
    public static class RavenExtensions
    {
        public static IDocumentStore EnsureExists(this IDocumentStore store)
        {
            try
            {
                using var dbSession = store.OpenSession();
                dbSession.Query<Order>().Take(0).ToList();
            }
            catch (Raven.Client.Exceptions.Database.DatabaseDoesNotExistException)
            {
                store.Maintenance.Server.Send(new Raven.Client.ServerWide.Operations.CreateDatabaseOperation(new Raven.Client.ServerWide.DatabaseRecord
                {
                    DatabaseName = store.Database
                }));
            }

            return store;
        }
    }
}
