﻿namespace Grupo_5_CE1_MN.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Grupo_5_CE1_MN.Models.CE01Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Grupo_5_CE1_MN.Models.CE01Context";
        }

        protected override void Seed(Grupo_5_CE1_MN.Models.CE01Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
