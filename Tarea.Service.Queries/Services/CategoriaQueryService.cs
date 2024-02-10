using Common.Collection;
using Common.Mapping;
using Common.Paging;
using Microsoft.EntityFrameworkCore;
using Tarea.Persistence.Database;
using Tarea.Service.Queries.DTOs;
using Tarea.Service.Queries.Interfaces;

namespace Tarea.Service.Queries.Services
{
    public class CategoriaQueryService : ICategoriaQueryService
    {
        private readonly TareaDbContext _context;

        public CategoriaQueryService(TareaDbContext context)
        {
            _context = context;
        }

        public async Task<DataCollection<CategoriaDTO>> GetAllAsync(int page, int take, IEnumerable<Guid> categorias = null)
        {
            var colletion = await _context.Categorias
                                  .Where(x => categorias == null || categorias.Contains(x.IdCategoria))
                                  .OrderByDescending(x => x.IdCategoria)
                                  .GetPagedAsync(page, take);

            return colletion.MapTo<DataCollection<CategoriaDTO>>();
        }

        public async Task<CategoriaDTO> GetAsync(Guid id)
        {
            return (await _context.Categorias.SingleAsync(x=>x.IdCategoria == id)).MapTo<CategoriaDTO>();
        }

    }
}
