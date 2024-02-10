using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea.Persistence.Database.Models;
using Tarea.Persistence.Database;
using Tarea.Service.EventHandlers.Commands;
using Microsoft.EntityFrameworkCore;
using MediatR;

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
                IdTarea = command.IdTarea
            };

            _context.Tareas.Remove(model);
            await _context.SaveChangesAsync();

        }
    }
}
