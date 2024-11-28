using FitVital.DAL;
using FitVital.DAL.Entities;
using FitVital.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace FitVital.Domain.Services
{
    public class AdministradorService : IAdministradorService
    {
        private readonly DataBaseContext _context;
        public AdministradorService(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Administrador>> GetAdministradorsAsync()
        {
            try
            {
                return await _context.Administradors.ToListAsync();
            }
            catch (DbUpdateException dbUdateException)
            {
                throw new Exception(dbUdateException.InnerException?.Message ?? dbUdateException.Message);
            }

        }
        public async Task<Administrador> CreateAdministradorAsync(Administrador administrador)
        {


            try
            {
                administrador.Id = Guid.NewGuid();
                administrador.CreatedDate = DateTime.Now;
                _context.Administradors.Add(administrador); //Metodo add permite crea objeto en el contexto de base de datos
                await _context.SaveChangesAsync(); //Guardar pais en tabla contry
                return administrador;
            }
            catch (DbUpdateException dbUdateException)
            {
                throw new Exception(dbUdateException.InnerException?.Message ?? dbUdateException.Message);
            }
        }
        public async Task<Administrador> GetAdministradorByIdAsync(Guid id)
        {
            try
            {
                return await _context.Administradors.FirstOrDefaultAsync(c => c.Id == id);
            }
            catch (DbUpdateException dbUdateException)
            {
                throw new Exception(dbUdateException.InnerException?.Message ?? dbUdateException.Message);
            }
        }

        public async Task<Administrador> EditAdministradorAsync(Administrador administrador)
        {
            try
            {
                administrador.ModifiedDate = DateTime.Now;
                _context.Administradors.Update(administrador);
                await _context.SaveChangesAsync();
                return administrador;
            }
            catch (DbUpdateException dbUdateException)
            {
                throw new Exception(dbUdateException.InnerException?.Message ?? dbUdateException.Message);
            }
        }
        public async Task<Administrador> DeleteAdministradorAsync(Guid id)
        {
            try
            {
                var administrador = await GetAdministradorByIdAsync(id);
                if (administrador != null)
                {
                    return administrador;
                }
                _context.Administradors.Remove(administrador);
                await _context.SaveChangesAsync();
                return administrador;
            }
            catch (DbUpdateException dbUdateException)
            {
                throw new Exception(dbUdateException.InnerException?.Message ?? dbUdateException.Message);
            }
        }

    }
}
