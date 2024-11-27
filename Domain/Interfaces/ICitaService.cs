using FitVital.DAL.Entities;

namespace FitVital.Domain.Interfaces
{
    public interface ICitaService
    {
        Task<Cita> CreateCitaAsync(Cita cita);

        Task<Cita> GetCitaByIdAsync(Guid id);

        Task<Cita> EditCitaAsync(Cita cita);

        Task<Cita> DeleteCitaAsync(Guid id);
    }
}
