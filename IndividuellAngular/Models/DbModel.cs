using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace IndividuellAngular.Models
{
    public class FAQ
    {
        [Key]
        public int id { get; set; }
        public string sporsmal { get; set; }
        public string svar { get; set; }
        public int kategoriId { get; set; }
        public Kategori kategoriNavn { get; set; }
        public int upvote { get; set; }
        public int downvote { get; set; }
    }

    public class Kategori
    {
        [Key]
        public int kategoriId { get; set; }
        public string kategoriNavn { get; set; }
    }

    public class InnSporsmal
    {
        [Key]
        public int id { get; set; }
        public string navn { get; set; }
        public string email { get; set; }
        public string sporsmal { get; set; }
    }

    public class KundeServiceContext : DbContext
    {
        public KundeServiceContext(DbContextOptions<KundeServiceContext> options)
        : base(options) { }

        public DbSet<Kategori> AlleKategorier { get; set; }
        public DbSet<FAQ> AlleFaq { get; set; }
        public DbSet<InnSporsmal> AlleInnSporsmal { get; set; }

        //Metode for å seede til database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedToDatabase();
        }
    }


}
