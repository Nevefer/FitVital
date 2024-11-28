using FitVital.DAL.Entities;
using System.Diagnostics.Metrics;

namespace FitVital.Domain.Interfaces
{
    public interface IAdministradorService
    {
        Task<IEnumerable<Administrador>> GetAdministradorsAsync(); //una de las tantas firmas de un metodo!

        Task<Administrador> CreateAdministradorAsync(Administrador administrador);

        Task<Administrador> GetAdministradorByIdAsync(Guid id);

        Task<Administrador> EditAdministradorAsync(Administrador administrador);

        Task<Administrador> DeleteAdministradorAsync(Guid id);
    }
}
