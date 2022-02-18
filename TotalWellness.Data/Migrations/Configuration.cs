namespace TotalWellness.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TotalWellness.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "TotalWellness.Data.ApplicationDbContext";
        }

        protected override void Seed(TotalWellness.Data.ApplicationDbContext context)
        {
            context.Teams.AddOrUpdate(t => t.TeamId,
                new Team() { TeamName = "Blue Bears" },
                new Team() { TeamName = "Yellow Yorkies" },
                new Team() { TeamName = "Red Rabbits" },
                new Team() { TeamName = "Pink Pandas" },
                new Team() { TeamName = "Green Geckos" },
                new Team() { TeamName = "Orange Otters" }
                );

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
