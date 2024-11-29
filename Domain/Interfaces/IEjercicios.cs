using FitVital.DAL.Entities;
using System.Diagnostics.Metrics;

namespace FitVital.Domain.Interfaces
{
    public interface IEjercicios
    {
        Task<IEnumerable<Ejercicio>> GetEjercicioAsync(Guid id);
        Task<Ejercicio> CreateEjercicioAsync(Ejercicio ejercicio);
        Task<Ejercicio> GetEjercicioByIdAsync(Guid id);
        Task<Ejercicio> EditEjercicioAsync(Ejercicio ejercicio);
        Task<Ejercicio> DeleteEjercicioAsync(Guid Id);
    }
}
