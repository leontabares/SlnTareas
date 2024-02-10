using System.ComponentModel.DataAnnotations;

namespace Tarea.Persistence.Database.Models
{
    public class CategoriaModel
    {
        [Key]
        public Guid IdCategoria { get; set; }
        public string? Descripcion { get; set; }
    }
}
