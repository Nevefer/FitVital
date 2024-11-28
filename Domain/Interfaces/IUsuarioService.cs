using FitVital.DAL.Entities;
using System.Diagnostics.Metrics;

namespace FitVital.Domain.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> GetUsuarioAsync(); //una de las tantas firmas de un metodo!

        Task<Usuario> CreateUsuarioAsync(Usuario usuario);

        Task<Usuario> GetUsuarioByIdAsync(Guid id);

        Task<Usuario> EditUsuarioAsync(Usuario usuario);

        Task<Usuario> DeleteUsuarioAsync(Guid id);
    }
}