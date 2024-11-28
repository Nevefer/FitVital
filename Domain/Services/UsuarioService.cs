using FitVital.DAL;
using FitVital.DAL.Entities;
using FitVital.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace FitVital.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly DataBaseContext _context;
        public UsuarioService(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Usuario>> GetUsuarioAsync()
        {
            try
            {
                return await _context.Usuarios.ToListAsync();
            }
            catch (DbUpdateException dbUdateException)
            {
                throw new Exception(dbUdateException.InnerException?.Message ?? dbUdateException.Message);
            }

        }
        public async Task<Usuario> CreateUsuarioAsync(Usuario usuario)
        {


            try
            {
                usuario.Id = Guid.NewGuid();
                usuario.CreatedDate = DateTime.Now;
                _context.Usuarios.Add(usuario); //Metodo add permite crea objeto en el contexto de base de datos
                await _context.SaveChangesAsync(); //Guardar pais en tabla contry
                return usuario;
            }
            catch (DbUpdateException dbUdateException)
            {
                throw new Exception(dbUdateException.InnerException?.Message ?? dbUdateException.Message);
            }
        }
        public async Task<Usuario> GetUsuarioByIdAsync(Guid id)
        {
            try
            {
                return await _context.Usuarios.FirstOrDefaultAsync(c => c.Id == id);
            }
            catch (DbUpdateException dbUdateException)
            {
                throw new Exception(dbUdateException.InnerException?.Message ?? dbUdateException.Message);
            }
        }

        public async Task<Usuario> EditUsuarioAsync(Usuario usuario)
        {
            try
            {
                usuario.ModifiedDate = DateTime.Now;
                _context.Usuarios.Update(usuario);
                await _context.SaveChangesAsync();
                return usuario;
            }
            catch (DbUpdateException dbUdateException)
            {
                throw new Exception(dbUdateException.InnerException?.Message ?? dbUdateException.Message);
            }
        }
        public async Task<Usuario> DeleteUsuarioAsync(Guid id)
        {
            try
            {
                var usuario = await GetUsuarioByIdAsync(id);
                if (usuario != null)
                {
                    return usuario;
                }
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
                return usuario;
            }
            catch (DbUpdateException dbUdateException)
            {
                throw new Exception(dbUdateException.InnerException?.Message ?? dbUdateException.Message);
            }
        }

    }
}
