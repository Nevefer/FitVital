using FitVital.DAL.Entities;
using FitVital.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FitVital.Controllers
{
    [Route("api/[controller]")]//Nombre inicial de mi ruta,URL o PATH
    [ApiController]
    public class CitasController : Controller
    {
        private readonly ICitaService _citaService;

        public CitasController(ICitaService citaService)
        {
            _citaService = citaService;
        }
        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")]//Api/Nutricionistas/get
        public async Task<ActionResult<IEnumerable<Cita>>> GetCitaByIdAsync(Guid id)
        {
            var cita = await _citaService.GetCitaByIdAsync(id);

            if (cita == null) return NotFound();//Not Found = status code 404

            return Ok(cita);//Ok = status code 200
        }
        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<Cita>> CreateCitaAsync(Cita cita)
        {
            try
            {
                var new_cita = await _citaService.CreateCitaAsync(cita);

                if (new_cita == null) return NotFound();

                return Ok(new_cita);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", cita.Id));
                return Conflict(ex.Message);
            }
        }
        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<Cita>> EditCitaAsync(Cita cita)
        {
            try
            {
                var editedcita = await _citaService.EditCitaAsync(cita);

                if (editedcita == null) return NotFound();

                return Ok(editedcita);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", cita.Id));
                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<Cita>> DeleteCitaAsync(Guid id)
        {
            if (id == null) return BadRequest();

            var Deletedcita = await _citaService.DeleteCitaAsync(id);

            if (Deletedcita == null) return NotFound();

            return Ok(Deletedcita);
        }
    }
}
