using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace FitVital.DAL.Entities
{
    public class Cita : AuditBase
    {
        //[Display(Name = "Nutricionista")]
        //public Nutricionista? Nutricionista { get; set; }
        //FK Nutricionista
        [Display(Name = "Id Nutricionista")]
        public Guid NutricionistaId { get; set; }


        //[Display(Name = "Usuario")]
        //public Usuario Usuario { get; set; }
        //FK Usuario
        [Display(Name = "Id Usuario")]
        public Guid UsuarioId { get; set; }


    }
}
