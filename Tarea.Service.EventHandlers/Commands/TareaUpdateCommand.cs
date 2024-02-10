using MediatR;

namespace Tarea.Service.EventHandlers.Commands
{
    public class TareaUpdateCommand : INotification
    {
        public Guid IdTarea { get; set; }
        public string? Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public Guid IdCategoria { get; set; }
        public bool Finalizada { get; set; }
    }
}
