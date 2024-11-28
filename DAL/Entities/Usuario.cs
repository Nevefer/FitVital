/*using System.ComponentModel.DataAnnotations;

namespace FitVital.DAL.Entities
{
    public class Usuario : AuditBase
    {
        [Display(Name = "Usuario")] // Identificar Nombre 
        [Required(ErrorMessage = "El campo {0} es olbigatorio")] // Obligatorio
        public String Name { get; set; }

        [Display(Name = "Contraseña")] // Identificar Nombre 
        [Required(ErrorMessage = "El campo {0} es olbigatorio")] // Obligatorio

        public String password { get; set; }

        public ICollection<Cita>? Citas { get; set; }
    }
}
*/

using System.ComponentModel.DataAnnotations;

namespace FitVital.DAL.Entities
{
    public class Usuario : AuditBase
    {
        [Display(Name = "Nombre")] // Identificar Nombre 
        
        [MaxLength(50, ErrorMessage = "El campo {0} dbe tener maximo {1} caracteres")] //Longitud MAxima
        public String Name { get; set; }

        
    }
}
    


        // Identificar Nombre 

        //public String password { get; set; }

        //public ICollection<Cita>? Citas { get; set; }