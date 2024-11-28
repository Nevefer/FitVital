using FitVital.DAL.Entities;
using FitVital.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FitVital.Controllers
{
    [Route("api/[controller]")]//Nombre inicial de mi ruta,URL o PATH
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            usuarioService = usuarioService;
        }
        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")]//Api/Usuario/get
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarioByIdAsync(Guid id)
        {
            var usuario = await _usuarioService.GetUsuarioByIdAsync(id);

            if (usuario == null) return NotFound();//Not Found = status code 404

            return Ok(usuario);//Ok = status code 200
        }
        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<Usuario>> CreateUsuarioAsync(Usuario usuario)
        {
            try
            {
                var new_usuario = await _usuarioService.CreateUsuarioAsync(usuario);

                if (new_usuario == null) return NotFound();

                return Ok(new_usuario);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", usuario.Id));
                return Conflict(ex.Message);
            }
        }
        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<Usuario>> EditUsuarioAsync(Usuario usuario)
        {
            try
            {
                var editedusuario = await _usuarioService.EditUsuarioAsync(usuario);

                if (editedusuario == null) return NotFound();

                return Ok(editedusuario);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", usuario.Id));
                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<Usuario>> DeleteUsuarioAsync(Guid id)
        {
            if (id == null) return BadRequest();

            var Deletedusuario = await _usuarioService.DeleteUsuarioAsync(id);

            if (Deletedusuario == null) return NotFound();

            return Ok(Deletedusuario);
        }
    }
}


