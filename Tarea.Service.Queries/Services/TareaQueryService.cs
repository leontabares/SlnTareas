using Common.Collection;
using Common.Mapping;
using Common.Paging;
using Microsoft.EntityFrameworkCore;
using Tarea.Persistence.Database;
using Tarea.Persistence.Database.Models;
using Tarea.Service.Queries.DTOs;
using Tarea.Service.Queries.Interfaces;

namespace Tarea.Service.Queries.Services
{
    public class TareaQueryService : ITareaQueryService
    {
        private readonly TareaDbContext _context;

        public TareaQueryService(TareaDbContext context)
        {
            _context = context;
        }

        public async Task<DataCollection<TareaDTO>> GetAllAsync(int page, int take, IEnumerable<Guid> tareas = null)
        {
            var colletion = await (from t in _context.Tareas
                       join c in _context.Categorias on t.Categoria equals c.IdCategoria
                       select new TareaDTO
                       {
                           IdTarea = t.IdTarea,
                           Descripcion = t.Descripcion,
                           Fecha = t.Fecha,
                           Finalizada = t.Finalizada,
                           Categoria = new CategoriaDTO
                           {
                               IdCategoria = c.IdCategoria,
                               Descripcion = c.Descripcion
                           }
                       }
                )
                .Where(x => tareas == null || tareas.Contains(x.IdTarea))
                .OrderByDescending(x => x.IdTarea)
                .GetPagedAsync(page, take);




            return colletion.MapTo<DataCollection<TareaDTO>>();
        }

        public async Task<TareaDTO> GetAsync(Guid id)
        {
            var tarea = await (from t in _context.Tareas
                               join c in _context.Categorias on t.Categoria equals c.IdCategoria
                               where t.IdTarea == id
                               select new TareaDTO
                               {
                                   IdTarea = t.IdTarea,
                                   Descripcion = t.Descripcion,
                                   Fecha = t.Fecha,
                                   Finalizada = t.Finalizada,
                                   Categoria = new CategoriaDTO
                                   {
                                       IdCategoria = c.IdCategoria,
                                       Descripcion = c.Descripcion
                                   }
                               }).FirstOrDefaultAsync();
        

            return (tarea).MapTo<TareaDTO>();
        }
    }
}
