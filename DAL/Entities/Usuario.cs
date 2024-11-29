using System.ComponentModel.DataAnnotations;

namespace FitVital.DAL.Entities
{
    public class Usuario : AuditBase
    {
        [Display(Name = "Usuario")] // Identificar Nombre 
        [Required(ErrorMessage = "El campo {0} es olbigatorio")] // Obligatorio
        public String Name { get; set; }

        [Display(Name = "Administrador")]
        //public Administrador? Administrador { set; get; }

        //FK Administrador
        //[Display(Name = "Id Administrador")]
        public Guid AdministradorId { get; set; }

        //public ICollection<Cita>? Citas { get; set; }

        //[Display(Name = "Id EjercicioUsuario")]
        //public EjercicioUsuario? EjercicioUsuarios { set; get; }

        //FK EjercicioUsuario
        [Display(Name = "Id EjercicioUsuario")]
        public Guid EjercicioUsuarioId { get; set; }
    }
}