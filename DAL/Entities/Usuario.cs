using System.ComponentModel.DataAnnotations;

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
<<<<<<< HEAD
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
=======
>>>>>>> 0440a048020652c5521d04bcb08f8b5b10eea01e
