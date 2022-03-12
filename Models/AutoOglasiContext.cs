using Microsoft.EntityFrameworkCore;

namespace Models{

    public class AutoOglasiContext : DbContext{

        public DbSet<Automobil> Automobili { get; set; }

        public DbSet<Korisnik> Korisnici { get; set; }

        public DbSet<Oglas> Oglasi { get; set; }   

        public DbSet<Pijaca> Pijace { get; set; }

        public AutoOglasiContext (DbContextOptions options) : base(options){

        }

        // protected override void OnModelCreating(ModelBuilder modelBuilder){
        //     base.OnModelCreating(modelBuilder);


        //     modelBuilder.Entity<Automobil>()
        //     .HasOne(p=>p.oglas)
        //     .WithOne(pp=>pp.automobil)
        //     .HasForeignKey<Oglas>(b => b.automobilFK);

        //     modelBuilder.Entity<Oglas>()
        //     .HasOne(s=>s.automobil)
        //     .WithOne(d=>d.oglas)
        //     .HasForeignKey<Automobil>(b => b.oglasFK);
        // }


        
    }
}