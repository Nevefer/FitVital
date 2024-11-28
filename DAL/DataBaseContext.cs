using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using FitVital.DAL.Entities;
using System.Diagnostics.Metrics;

namespace FitVital.DAL
{
    public class DataBaseContext : DbContext
    {
        // Me conecto a la BD por medio del constructor 
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        // Este metodo me sirve para configurar unos indices de cada campo de una BD
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Nutricionista>().HasIndex(c => c.Name).IsUnique();
            //modelBuilder.Entity<Usuario>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Cita>().HasIndex(c => c.Id).IsUnique();
<<<<<<< HEAD
            modelBuilder.Entity<Usuario>().HasIndex(c => c.Id);

=======
            modelBuilder.Entity<Ejercicio>().HasIndex(c => c.Id).IsUnique(); 
>>>>>>> 0440a048020652c5521d04bcb08f8b5b10eea01e
        }

        #region Dbsets
        public DbSet<Nutricionista> Nutricionistas { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cita> Citas { get; set; }

<<<<<<< HEAD
        public DbSet<Administrador> Administradors { get; set; }
=======
        public DbSet<Ejercicio> Ejercicio { get; set; } 
>>>>>>> 0440a048020652c5521d04bcb08f8b5b10eea01e

        #endregion
    }

    public class YourDbContextFactory : IDesignTimeDbContextFactory<DataBaseContext>
    {
        public DataBaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataBaseContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=FitVital;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new DataBaseContext(optionsBuilder.Options);
        }
    }
}
