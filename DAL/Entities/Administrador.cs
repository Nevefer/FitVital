using System.ComponentModel.DataAnnotations;

namespace FitVital.DAL.Entities
{
    public class Administrador : AuditBase
    {
        [Display(Name = "Usuario")] // Identificar Nombre 
        [Required(ErrorMessage = "El campo {0} es olbigatorio")] // Obligatorio
        [MaxLength(50, ErrorMessage = "El campo {0} dbe tener maximo {1} caracteres")] //Longitud MAxima
        public String Name { get; set; }

        [Required(ErrorMessage = "El campo {0} es olbigatorio")] // Obligatorio
        [Display(Name = "Contraseña")] // Identificar Nombre 

        public String password { get; set; }

        //public ICollection<Usuario>? Usuarios { get; set; }

        //public ICollection<Ejercicio>? Ejercicios { get; set; }
    }
}