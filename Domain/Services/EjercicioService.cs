using FitVital.DAL.Entities;
using FitVital.DAL;
using FitVital.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitVital.Domain.Services
{
    public class EjercicioService : IEjercicios
    {
        private readonly DataBaseContext _context;
        public EjercicioService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<Ejercicio> CreateEjercicioAsync(Ejercicio ejercicio)
        {


            try
            {
                ejercicio.Id = Guid.NewGuid();
                ejercicio.CreatedDate = DateTime.Now;
                _context.Ejercicio.Add(ejercicio); //Metodo add permite crea objeto en el contexto de base de datos
                await _context.SaveChangesAsync(); //Guardar pais en tabla contry
                return ejercicio;
            }
            catch (DbUpdateException dbUdateException)
            {
                throw new Exception(dbUdateException.InnerException?.Message ?? dbUdateException.Message);
            }
        }
        public async Task<Ejercicio> GetEjercicioByIdAsync(Guid id)
        {
            try
            {
                return await _context.Ejercicio.FirstOrDefaultAsync(c => c.Id == id); // Verfificar
            }
            catch (DbUpdateException dbUdateException)
            {
                throw new Exception(dbUdateException.InnerException?.Message ?? dbUdateException.Message);
            }
        }

        public async Task<Ejercicio> EditEjercicioAsync(Ejercicio ejercicio)
        {
            try
            {
                
                ejercicio.ModifiedDate = DateTime.Now;
                _context.Ejercicio.Update(ejercicio);
                await _context.SaveChangesAsync();
                return ejercicio; 
            }
            catch (DbUpdateException dbUdateException)
            {
                throw new Exception(dbUdateException.InnerException?.Message ?? dbUdateException.Message);
            }
        }
        public async Task<Ejercicio> DeleteEjercicioAsync(Guid id)
        {
            try
            {
                var ejercicio = await GetEjercicioByIdAsync(id);
                if (ejercicio != null)
                {
                    return ejercicio;
                }
                _context.Ejercicio.Remove(ejercicio);
                await _context.SaveChangesAsync();
                return ejercicio;
            }
            catch (DbUpdateException dbUdateException)
            {
                throw new Exception(dbUdateException.InnerException?.Message ?? dbUdateException.Message);
            }
        }

        public Task<IEnumerable<Ejercicio>> GetEjercicioAsync()
        {
            throw new NotImplementedException();
        }

        Task<Ejercicio> IEjercicios.GetEjercicioByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<Ejercicio> IEjercicios.EditEjercicioAsync(Ejercicio ejercicio)
        {
            throw new NotImplementedException();
        }

       
    }

}

