using System.ComponentModel.DataAnnotations;


namespace Tarea.Persistence.Database.Models
{
    public class TareaModel
    {
        [Key]
        public Guid IdTarea { get; set; }
        public string? Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public Guid Categoria { get; set; }
        public bool Finalizada { get; set; }
    }
}
