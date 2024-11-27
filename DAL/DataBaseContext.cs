using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using FitVital.DAL.Entities;

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
        }

        #region Dbsets
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
