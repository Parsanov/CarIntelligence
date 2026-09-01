using Core.Model;
using Microsoft.EntityFrameworkCore;

namespace Persistence.DBContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Довідник — наповнюється руками, майже не змінюється
        public DbSet<Makes> Makes => Set<Makes>();
        public DbSet<Models> Models => Set<Models>();
        public DbSet<Generations> Generations => Set<Generations>();
        public DbSet<Engine> Engines => Set<Engine>();
        public DbSet<GearBox> GearBoxes => Set<GearBox>();
        public DbSet<Suspensions> Suspensions => Set<Suspensions>();
        public DbSet<Powertrains> Powertrains => Set<Powertrains>();

        // Знання — головний актив
        public DbSet<EngineIssues> EngineIssues => Set<EngineIssues>();
        public DbSet<GearboxIssues> GearboxIssues => Set<GearboxIssues>();
        public DbSet<SuspensionsIssues> SuspensionsIssues => Set<SuspensionsIssues>();
        public DbSet<BodyIssues> BodyIssues => Set<BodyIssues>();

        // Ринок і вивід
        public DbSet<Listings> Listings => Set<Listings>();
        public DbSet<Analyses> Analyses => Set<Analyses>();
        public DbSet<Explanations> Explanations => Set<Explanations>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Підхоплює всі IEntityTypeConfiguration з цієї збірки
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
