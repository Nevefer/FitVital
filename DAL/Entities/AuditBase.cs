using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace FitVital.DAL.Entities
{
    public class AuditBase
    {
        [Key] //PK
        [Required] // Obligatorio
        public virtual Guid Id { get; set; } // Sera PK de todas las tablas 
            
        public virtual DateTime? CreatedDate { get; set; } // Para guardar todo registro con su fecha
            
        public virtual DateTime? ModifiedDate { get; set; } // para guardar cambio en todo registro  
    }
}
