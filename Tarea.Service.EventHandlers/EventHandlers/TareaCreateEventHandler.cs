using MediatR;
using Tarea.Persistence.Database;
using Tarea.Persistence.Database.Models;
using Tarea.Service.EventHandlers.Commands;

namespace Tarea.Service.EventHandlers.EventHandlers
{
    public class TareaCreateEventHandler : INotificationHandler<TareaCreateCommand>
    {
        private readonly TareaDbContext _context;
        public TareaCreateEventHandler(TareaDbContext context)
        {
            _context = context;
        }

        public async Task Handle(TareaCreateCommand command, CancellationToken cancellationToken)
        {
            var exist = _context.Tareas.Where(x=>x.IdTarea.Equals(command.IdTarea)).Any();

            if (!exist) {
                await _context.AddAsync(new TareaModel
                {
                    IdTarea = Guid.Parse(command.IdTarea),
                    Descripcion = command.Descripcion,
                    Finalizada = command.Finalizada,
                    Fecha = Convert.ToDateTime(command.Fecha),
                    Categoria = Guid.Parse(command.IdCategoria)
                });

                await _context.SaveChangesAsync();
            }


        }
    }
}
