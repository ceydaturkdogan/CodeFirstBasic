using CodeFirstBasic.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstBasic.Context
{
    public class PatikaFirstDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-8789393\\SQLEXPRESS01;PatikaCodeFirstDb1 ;Trusted_Connection=true");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("Movies")
                      .HasKey(x => x.Id);

            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("Games")
                      .HasKey(x => x.Id);

                entity.Property(x => x.Rating)
                      .HasColumnType("decimal(5,3)")
                      .IsRequired();


                entity.HasCheckConstraint("Games Rating","Rating >= 0 AND Rating <= 10");


            });
        }
    }
}