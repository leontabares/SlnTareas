using MediatR;

namespace Tarea.Service.EventHandlers.Commands
{
    public class CategoriaCreateCommand : INotification
    {
        public Guid IdCategoria { get; set; }
        public string? Descripcion { get; set; }
    }
}
