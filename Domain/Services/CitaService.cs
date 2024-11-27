using FitVital.DAL.Entities;
using FitVital.DAL;
using Microsoft.EntityFrameworkCore;
using FitVital.Domain.Interfaces;

namespace FitVital.Domain.Services
{
    public class CitaService : ICitaService
    {
        private readonly DataBaseContext _context;
        public CitaService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<Cita> CreateCitaAsync(Cita cita)
        {


            try
            {
                cita.Id = Guid.NewGuid();
                cita.CreatedDate = DateTime.Now;
                _context.Citas.Add(cita); //Metodo add permite crea objeto en el contexto de base de datos
                await _context.SaveChangesAsync(); //Guardar pais en tabla contry
                return cita;
            }
            catch (DbUpdateException dbUdateException)
            {
                throw new Exception(dbUdateException.InnerException?.Message ?? dbUdateException.Message);
            }
        }
        public async Task<Cita> GetCitaByIdAsync(Guid id)
        {
            try
            {
                return await _context.Citas.FirstOrDefaultAsync(c => c.Id == id);
            }
            catch (DbUpdateException dbUdateException)
            {
                throw new Exception(dbUdateException.InnerException?.Message ?? dbUdateException.Message);
            }
        }

        public async Task<Cita> EditCitaAsync(Cita cita)
        {
            try
            {
                cita.ModifiedDate = DateTime.Now;
                _context.Citas.Update(cita);
                await _context.SaveChangesAsync();
                return cita;
            }
            catch (DbUpdateException dbUdateException)
            {
                throw new Exception(dbUdateException.InnerException?.Message ?? dbUdateException.Message);
            }
        }
        public async Task<Cita> DeleteCitaAsync(Guid id)
        {
            try
            {
                var cita = await GetCitaByIdAsync(id);
                if (cita != null)
                {
                    return cita;
                }
                _context.Citas.Remove(cita);
                await _context.SaveChangesAsync();
                return cita;
            }
            catch (DbUpdateException dbUdateException)
            {
                throw new Exception(dbUdateException.InnerException?.Message ?? dbUdateException.Message);
            }
        }
    }
}
