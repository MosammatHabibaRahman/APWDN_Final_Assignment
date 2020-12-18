namespace FinalAsmntBlogPostSystem.Migrations
{
    using FinalAsmntBlogPostSystem.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FinalAsmntBlogPostSystem.Models.CFBlogPostDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = nameof(CFBlogPostDbContext);
        }

        protected override void Seed(FinalAsmntBlogPostSystem.Models.CFBlogPostDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
