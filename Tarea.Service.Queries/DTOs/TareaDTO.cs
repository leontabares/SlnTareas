namespace Tarea.Service.Queries.DTOs
{
    public class TareaDTO
    {
        public Guid IdTarea { get; set; }
        public string? Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public CategoriaDTO Categoria { get; set; }
        public bool Finalizada { get; set; }
    }
}
