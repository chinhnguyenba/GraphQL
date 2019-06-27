using System;
using GraphQL.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Data
{
    public sealed class GraphQLDbContext:DbContext
    {
        public GraphQLDbContext(DbContextOptions options)
            : base(options)
        {
            // these are mutually exclusive, migrations cannot be used with EnsureCreated()
            // Database.EnsureCreated();
            //Database.Migrate();
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<SkaterStatistic> SkaterStatistics { get; set; }
    }
}
