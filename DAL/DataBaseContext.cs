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

            modelBuilder.Entity<Cita>().HasIndex(c => c.Id).IsUnique();

            modelBuilder.Entity<Usuario>().HasIndex(c => c.Id);

            modelBuilder.Entity<Ejercicio>().HasIndex(c => c.Id).IsUnique();

            modelBuilder.Entity<EjercicioUsuario>().HasIndex(c => c.Id).IsUnique();

            modelBuilder.Entity<Administrador>().HasIndex(c => c.Id).IsUnique();
            
        }

        #region Dbsets
        public DbSet<Nutricionista> Nutricionistas { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cita> Citas { get; set; }

        public DbSet<Administrador> Administradors { get; set; }
        public DbSet<Ejercicio> Ejercicios { get; set; }

        public DbSet<EjercicioUsuario> EjercicioUsuarios { get; set; }

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
