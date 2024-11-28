using FitVital.DAL.Entities;
using FitVital.Domain.Interfaces;
using FitVital.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace FitVital.Controllers
{
    [Route("api/[controller]")]//Nombre inicial de mi ruta,URL o PATH
    [ApiController]
    public class AdministradorController : Controller
    {
        private readonly IAdministradorService _administradorService;

        public AdministradorController(IAdministradorService administradorService)
        {
            _administradorService = administradorService;
        }
        [HttpGet, ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Administrador>>> GetAdministradorAsync()
        {
            var Administradors = await _administradorService.GetAdministradorsAsync();

            if (Administradors == null || !Administradors.Any()) return NotFound();

            return Ok(Administradors);
        }
        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")]//Api/Administradors/get
        public async Task<ActionResult<IEnumerable<Administrador>>> GetAdministradorByIdAsync(Guid id)
        {
            var administrador = await _administradorService.GetAdministradorByIdAsync(id);

            if (administrador == null) return NotFound();//Not Found = status code 404

            return Ok(administrador);//Ok = status code 200
        }
        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<Administrador>> CreateAdministradorAsync(Administrador adminstrador)
        {
            try
            {
                var new_administrador = await _administradorService.CreateAdministradorAsync(adminstrador);

                if (new_administrador == null) return NotFound();

                return Ok(new_administrador);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", adminstrador.Name));
                return Conflict(ex.Message);
            }
        }
        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<Administrador>> EditAdministradorAsync(Administrador administrador)
        {
            try
            {
                var editedadministrador = await _administradorService.EditAdministradorAsync(administrador);

                if (editedadministrador == null) return NotFound();

                return Ok(editedadministrador);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", administrador.Name));
                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<Administrador>> DeleteAdministradorAsync(Guid id)
        {
            if (id == null) return BadRequest();

            var Deletedadministrador = await _administradorService.DeleteAdministradorAsync(id);

            if (Deletedadministrador == null) return NotFound();

            return Ok(Deletedadministrador);
        }
    }
}
