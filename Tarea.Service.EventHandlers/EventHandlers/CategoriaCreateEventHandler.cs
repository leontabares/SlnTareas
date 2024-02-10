using MediatR;
using Tarea.Persistence.Database;
using Tarea.Persistence.Database.Models;
using Tarea.Service.EventHandlers.Commands;

namespace Tarea.Service.EventHandlers.EventHandlers
{
    public class CategoriaCreateEventHandler : INotificationHandler<CategoriaCreateCommand>
    {
        private readonly TareaDbContext _context;
        public CategoriaCreateEventHandler(TareaDbContext context) 
        {
            _context = context;
        }

        public async Task Handle(CategoriaCreateCommand command, CancellationToken cancellationToken)
        {
            await _context.AddAsync(new CategoriaModel
            {
                IdCategoria = command.IdCategoria,
                Descripcion = command.Descripcion                 
            });

            await _context.SaveChangesAsync();
        }


        //public async Task Handle(CategoriaUpdateCommand command)
        //{
        //    await _context.AddAsync(new CategoriaModel
        //    {
        //        IdCategoria = command.IdCategoria,
        //        Descripcion = command.Descripcion
        //    });

        //    await _context.SaveChangesAsync();
        //}

        //public async Task Handle(CategoriaDeleteCommand command)
        //{
        //    await _context.AddAsync(new CategoriaModel
        //    {
        //        IdCategoria = command.IdCategoria,
        //        Descripcion = command.Descripcion
        //    });

        //    await _context.SaveChangesAsync();
        //}
    }
}
