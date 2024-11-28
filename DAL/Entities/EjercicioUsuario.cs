using System.ComponentModel.DataAnnotations;

namespace FitVital.DAL.Entities
{
    public class EjercicioUsuario : AuditBase
    {
        [Display(Name = "EjerciciosUsuario")] // Identificar Nombre 
        public EjercicioUsuario? Ejercicio { get; set; }

        [Display(Name = "ID Ejercicio")]
        public Guid IdEjercicio {  set; get; }
        public Guid Name { get; set; }

        public ICollection<Ejercicio>? Ejercicios { get; set; }
        public ICollection<Usuario>? Usuarios { get; set; }


    }
}
