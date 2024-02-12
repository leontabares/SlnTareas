using MediatR;

namespace Tarea.Service.EventHandlers.Commands
{
    public class TareaDeleteCommand : INotification
    {
        public string? IdTarea { get; set; }
    }
}
