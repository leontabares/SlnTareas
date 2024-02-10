using Common.Collection;
using Tarea.Service.Queries.DTOs;

namespace Tarea.Service.Queries.Interfaces
{
    public interface ITareaQueryService
    {
        Task<DataCollection<TareaDTO>> GetAllAsync(int page, int take, IEnumerable<Guid> tareas = null);
        Task<TareaDTO> GetAsync(Guid id);
    }
}
