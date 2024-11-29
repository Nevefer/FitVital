using FitVital.DAL.Entities;
using FitVital.Domain.Interfaces;
using FitVital.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitVital.Controllers
{
    [Route("api/[controller]")]//Nombre inicial de mi ruta,URL o PATH
    [ApiController]

    public class EjerciciosController : Controller
    {
        private readonly IEjercicios _ejercicios;
        public EjerciciosController(IEjercicios Ejercicios)
        {
            _ejercicios = Ejercicios;
        }
        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")]//Api/Ejercicios/get
        public async Task<ActionResult<IEnumerable<Ejercicio>>> GetEjercicioByIdAsync(Guid Id)
        {
            var ejercicio = await _ejercicios.GetEjercicioByIdAsync(Id);

            if (ejercicio == null) return NotFound();//Not Found = status code 404

            return Ok(ejercicio);//Ok = Status code 200
        }
        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<Ejercicio>> CreateEjercicioAsync(Ejercicio ejercicio)
        {
            try
            {
                var new_ejercicio = await _ejercicios.CreateEjercicioAsync(ejercicio);

                if (new_ejercicio == null) return NotFound();

                return Ok(new_ejercicio);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", ejercicio.Id));
                return Conflict(ex.Message);
            }
        }
        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<Cita>> EditEjercicioAsync(Ejercicio ejercicio)
        {
            try
            {
                var EditedEjercicio = await _ejercicios.EditEjercicioAsync(ejercicio);

                if (EditedEjercicio == null) return NotFound();

                return Ok(EditedEjercicio);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", ejercicio.Id));
                return Conflict(ex.Message);
            }
        }
        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<Cita>> DeleteEjercicioAsync(Guid id)
        {
            if (id == null) return BadRequest();

            var DeletedEjercicio = await _ejercicios.DeleteEjercicioAsync(id);

            if (DeletedEjercicio == null) return NotFound();

            return Ok(DeletedEjercicio);
        }
        [HttpGet, ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Ejercicio>>> GetEjercicioAsync(Guid Id)
        {
            var ejercicio = await _ejercicios.GetEjercicioAsync(Id);

            if (ejercicio == null) return NotFound();//Not Found = status code 404

            return Ok(ejercicio);//Ok = Status code 200
        }
    }
}

