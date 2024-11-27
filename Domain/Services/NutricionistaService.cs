using FitVital.DAL;
using FitVital.DAL.Entities;
using FitVital.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace FitVital.Domain.Services
{
    public class NutricionistaService : INutricionistaService
    {
        private readonly DataBaseContext _context;
        public NutricionistaService(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Nutricionista>> GetNutricionistasAsync()
        {
            try
            {
                return await _context.Nutricionistas.ToListAsync();
            }
            catch (DbUpdateException dbUdateException)
            {
                throw new Exception(dbUdateException.InnerException?.Message ?? dbUdateException.Message);
            }

        }
        public async Task<Nutricionista> CreateNutricionistaAsync(Nutricionista nutricionista)
        {


            try
            {
                nutricionista.Id = Guid.NewGuid();
                nutricionista.CreatedDate = DateTime.Now;
                _context.Nutricionistas.Add(nutricionista); //Metodo add permite crea objeto en el contexto de base de datos
                await _context.SaveChangesAsync(); //Guardar pais en tabla contry
                return nutricionista;
            }
            catch (DbUpdateException dbUdateException)
            {
                throw new Exception(dbUdateException.InnerException?.Message ?? dbUdateException.Message);
            }
        }
        public async Task<Nutricionista> GetNutricionistaByIdAsync(Guid id)
        {
            try
            {
                return await _context.Nutricionistas.FirstOrDefaultAsync(c => c.Id == id);
            }
            catch (DbUpdateException dbUdateException)
            {
                throw new Exception(dbUdateException.InnerException?.Message ?? dbUdateException.Message);
            }
        }

        public async Task<Nutricionista> EditNutricionistaAsync(Nutricionista nutricionista)
        {
            try
            {
                nutricionista.ModifiedDate = DateTime.Now;
                _context.Nutricionistas.Update(nutricionista);
                await _context.SaveChangesAsync();
                return nutricionista;
            }
            catch (DbUpdateException dbUdateException)
            {
                throw new Exception(dbUdateException.InnerException?.Message ?? dbUdateException.Message);
            }
        }
        public async Task<Nutricionista> DeleteNutricionistaAsync(Guid id)
        {
            try
            {
                var nutricionista = await GetNutricionistaByIdAsync(id);
                if (nutricionista != null)
                {
                    return nutricionista;
                }
                _context.Nutricionistas.Remove(nutricionista);
                await _context.SaveChangesAsync();
                return nutricionista;
            }
            catch (DbUpdateException dbUdateException)
            {
                throw new Exception(dbUdateException.InnerException?.Message ?? dbUdateException.Message);
            }
        }

    }
}

