using MediatR;
using Tarea.Persistence.Database;
using Tarea.Persistence.Database.Models;
using Tarea.Service.EventHandlers.Commands;

namespace Tarea.Service.EventHandlers.EventHandlers
{
    public class TareaUpdateEventHandler : INotificationHandler<TareaUpdateCommand>
    {
        private readonly TareaDbContext _context;
        public TareaUpdateEventHandler(TareaDbContext context)
        {
            _context = context;
        }

        public async Task Handle(TareaUpdateCommand command, CancellationToken cancellationToken)
        {
            TareaModel model = new()
            {
                IdTarea = Guid.Parse(command.IdTarea),
                Descripcion = command.Descripcion,
                Finalizada = command.Finalizada,
                Fecha = Convert.ToDateTime(command.Fecha),
                Categoria = Guid.Parse(command.IdCategoria)
            };

            _context.Tareas.Update(model);
            await _context.SaveChangesAsync();

        }
    }
}
