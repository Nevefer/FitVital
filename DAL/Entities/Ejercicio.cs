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

        [Display(Name = " Id Ejercicio")]

        public Guid IdEjercicio { get; set; }

        [Display(Name = "Ejercicio")]
        public Ejercicio? ejercicio {  set; get; }

        public ICollection<EjercicioUsuario>? ejercicioUsuarios { get; set; }

        


        
    }
}
