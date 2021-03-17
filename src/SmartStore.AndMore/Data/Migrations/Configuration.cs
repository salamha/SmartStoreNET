namespace SmartStore.AndMore.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SmartStore.AndMore.Data.SmartStoreAndMoreObjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Data\Migrations";
            ContextKey = "SmartStore.AndMore"; // DO NOT CHANGE!
        }

        protected override void Seed(SmartStore.AndMore.Data.SmartStoreAndMoreObjectContext context)
        {
        }
    }
}
