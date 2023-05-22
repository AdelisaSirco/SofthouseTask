using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Softhouse_Test_App.Models;

namespace Softhouse_Test_App.Data
{

    public class AppDbContext : DbContext
    {
       
            public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
            {
            }

            public DbSet<Characters> Characters { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                // Configure the table name
                modelBuilder.Entity<Characters>().ToTable("Characters");

                // Configure the primary key
                modelBuilder.Entity<Characters>().HasKey(c => c.Id);

                // Configure properties with collection types as JSON columns
                modelBuilder.Entity<Characters>().Property(c => c.Films).HasConversion(
                    films => JsonConvert.SerializeObject(films),
                    json => JsonConvert.DeserializeObject<List<string>>(json));

                modelBuilder.Entity<Characters>().Property(c => c.ShortFilms).HasConversion(
                    shortFilms => JsonConvert.SerializeObject(shortFilms),
                    json => JsonConvert.DeserializeObject<List<string>>(json));

                modelBuilder.Entity<Characters>().Property(c => c.TVShows).HasConversion(
                    tvShows => JsonConvert.SerializeObject(tvShows),
                    json => JsonConvert.DeserializeObject<List<string>>(json));

             
            }
        
    }
    
}
