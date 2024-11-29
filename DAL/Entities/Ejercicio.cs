using System.ComponentModel.DataAnnotations;

namespace FitVital.DAL.Entities
{
    public class Ejercicio : AuditBase 
    {
        [Display(Name = "Ejercicio")] // Identificar Nombre 
        [MaxLength(50, ErrorMessage = "El campo {0} dbe tener maximo {1} caracteres")] //Longitud MAxima
        [Required(ErrorMessage = "El campo {0} es olbigatorio")] // Obligatorio
        public string Name { get; set; }
        public string Type { get; set; }



        [Display(Name = "Administrador")]
        public Administrador? Administrador {  set; get; }

        //FK Administrador
        [Display(Name = "Id Administrador")]
        public Guid AdministradorId { get; set; }

        [Display(Name = "Id EjercicioUsuario")]
        public EjercicioUsuario? EjercicioUsuarios { set; get; }

        //FK EjercicioUsuario
        [Display(Name = "Id EjercicioUsuario")]
        public Guid EjercicioUsuarioId { get; set; }

    }
}
