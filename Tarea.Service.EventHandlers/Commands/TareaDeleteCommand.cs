using MediatR;

namespace Tarea.Service.EventHandlers.Commands
{
    public class TareaDeleteCommand : INotification
    {
        public Guid IdTarea { get; set; }
    }
}
