using Common.Collection;
using Tarea.Service.Queries.DTOs;

namespace Tarea.Service.Queries.Interfaces
{
    public interface ICategoriaQueryService
    {
        Task<DataCollection<CategoriaDTO>> GetAllAsync(int page, int take, IEnumerable<Guid> categorias = null);
        Task<CategoriaDTO> GetAsync(Guid id);
    }
}
