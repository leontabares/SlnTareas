using MediatR;
using Tarea.Persistence.Database;
using Tarea.Persistence.Database.Models;
using Tarea.Service.EventHandlers.Commands;

namespace Tarea.Service.EventHandlers.EventHandlers
{
    public class TareaDeleteEventHandler : INotificationHandler<TareaDeleteCommand>
    {
        private readonly TareaDbContext _context;
        public TareaDeleteEventHandler(TareaDbContext context)
        {
            _context = context;
        }

        public async Task Handle(TareaDeleteCommand command, CancellationToken cancellationToken)
        {
            TareaModel model = new()
            {
                IdTarea = Guid.Parse(command.IdTarea)
            };

            _context.Tareas.Remove(model);
            await _context.SaveChangesAsync();

        }
    }
}
