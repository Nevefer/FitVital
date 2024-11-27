using FitVital.DAL.Entities;
using System.Diagnostics.Metrics;

namespace FitVital.Domain.Interfaces
{
    public interface INutricionistaService
    {
        Task<IEnumerable<Nutricionista>> GetNutricionistasAsync(); //una de las tantas firmas de un metodo!

        Task<Nutricionista> CreateNutricionistaAsync(Nutricionista nutricionista);

        Task<Nutricionista> GetNutricionistaByIdAsync(Guid id);

        Task<Nutricionista> EditNutricionistaAsync(Nutricionista nutricionista);

        Task<Nutricionista> DeleteNutricionistaAsync(Guid id);
    }
}
