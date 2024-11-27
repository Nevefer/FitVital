namespace FitVital.DAL
{
    public class SeederDB
    {
        private readonly DataBaseContext _context;

        public SeederDB(DataBaseContext context)
        {
            _context = context;
        }

        //Seeder asign 
        //Metodo MAIN()
        //Este metodo prepobla diff tablas de la BD

        public async Task SeederAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            //Metodos para repoblar bd


            await _context.SaveChangesAsync();
        }
        #region Private methods
        #endregion
    }
}
