using MediatR;

namespace Tarea.Service.EventHandlers.Commands
{
    public class TareaCreateCommand : INotification
    {
        public string IdTarea { get; set; }
        public string? Descripcion { get; set; }
        public string Fecha { get; set; }
        public string IdCategoria { get; set; }
        public bool Finalizada { get; set; }
    }
}
