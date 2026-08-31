using Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DBContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Analyses> Analyses { get; set; }
        public DbSet<BodyIssues> BodyIssues { get; set; }
        public DbSet<EngineIssues> EngineIssues { get; set; }
        public DbSet<Powertrains> Powertrains { get; set; }
        public DbSet<Suspensions> Suspensions { get; set; }
        public DbSet<SuspensionsIssues> SuspensionsIssues { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<GearBox> GearBoxes { get; set; }
        public DbSet<GearboxIssues> GearboxIssues { get; set; }
        public DbSet<Models> Models { get; set; }
        public DbSet<Makes> Makes { get; set; }
        public DbSet<Generations> Generations { get; set; }
        public DbSet<Listings> Listings { get; set; }
        public DbSet<Explanations> Explanations { get; set; }

    }
}
