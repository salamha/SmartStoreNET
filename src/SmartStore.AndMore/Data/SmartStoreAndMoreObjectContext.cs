using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using SmartStore.Core;
using SmartStore.Data;
using SmartStore.Data.Setup;
using SmartStore.SmartStoreAndMore.Data.Migrations;
using SmartStore.SmartStoreAndMore.Domain;

namespace SmartStore.AndMore.Data
{
    /// <summary>
    /// Object context
    /// </summary>
    public class SmartStoreAndMoreObjectContext : ObjectContextBase
    {
        public const string ALIASKEY = "sm_object_context_SmartStoreAndMore";

        static SmartStoreAndMoreObjectContext()
        {
            var initializer = new MigrateDatabaseInitializer<SmartStoreAndMoreObjectContext, Configuration>
            {
                TablesToCheck = new[] { "SmartStoreAndMore" }
            };
            Database.SetInitializer(initializer);
        }

        /// <summary>
        /// For tooling support, e.g. EF Migrations
        /// </summary>
        public SmartStoreAndMoreObjectContext()
            : base()
        {
        }

        public SmartStoreAndMoreObjectContext(string nameOrConnectionString)
            : base(nameOrConnectionString, ALIASKEY)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SmartStoreAndMoreRecord>();

            //disable EdmMetadata generation
            //modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}