using System.ComponentModel.DataAnnotations;

namespace FitVital.DAL.Entities
{
    public class EjercicioUsuario : AuditBase
    {
        public ICollection<Usuario>? Usuarios { get; set; }

        public ICollection<Ejercicio>? Ejercicios { get; set; }
    }
}
