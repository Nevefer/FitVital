using FitVital.DAL.Entities;
using FitVital.Domain.Interfaces;
using FitVital.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace FitVital.Controllers
{
    [Route("api/[controller]")]//Nombre inicial de mi ruta,URL o PATH
    [ApiController]
    public class NutricionistasController : Controller
    {
        private readonly INutricionistaService _nutricionistaService;

        public NutricionistasController(INutricionistaService nutricionistaService)
        {
            _nutricionistaService = nutricionistaService;
        }
        [HttpGet, ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Nutricionista>>> GetNutricionistasAsync()
        {
            var Nutricionistas = await _nutricionistaService.GetNutricionistasAsync();

            if (Nutricionistas == null || !Nutricionistas.Any()) return NotFound();

            return Ok(Nutricionistas);
        }
        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")]//Api/Nutricionistas/get
        public async Task<ActionResult<IEnumerable<Nutricionista>>> GetNutricionistaByIdAsync(Guid id)
        {
            var nutricionista = await _nutricionistaService.GetNutricionistaByIdAsync(id);

            if (nutricionista == null) return NotFound();//Not Found = status code 404

            return Ok(nutricionista);//Ok = status code 200
        }
        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<Nutricionista>> CreateNutricionistaAsync(Nutricionista nutricionista)
        {
            try
            {
                var new_nutricionista = await _nutricionistaService.CreateNutricionistaAsync(nutricionista);

                if (new_nutricionista == null) return NotFound();

                return Ok(new_nutricionista);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", nutricionista.Name));
                return Conflict(ex.Message);
            }
        }
        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<Nutricionista>> EditNutricionistaAsync(Nutricionista nutricionista)
        {
            try
            {
                var editednutricionista = await _nutricionistaService.EditNutricionistaAsync(nutricionista);

                if (editednutricionista == null) return NotFound();

                return Ok(editednutricionista);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", nutricionista.Name));
                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<Nutricionista>> DeleteNutricionistaAsync(Guid id)
        {
            if (id == null) return BadRequest();

            var Deletednutricionista = await _nutricionistaService.DeleteNutricionistaAsync(id);

            if (Deletednutricionista == null) return NotFound();

            return Ok(Deletednutricionista);
        }
    }
}
