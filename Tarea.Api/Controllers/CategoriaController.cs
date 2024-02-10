using Common.Collection;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tarea.Service.EventHandlers.Commands;
using Tarea.Service.Queries.DTOs;
using Tarea.Service.Queries.Interfaces;

namespace Tarea.Api.Controllers
{
    [ApiController]
    [Route("Categoria")]
    public class CategoriaController : Controller
    {
        private readonly ILogger<CategoriaController> _logger;
        private readonly ICategoriaQueryService _queryService;
        private readonly IMediator _mediator;

        public CategoriaController(ILogger<CategoriaController> logger, ICategoriaQueryService queryService, IMediator mediator) 
        { 
            _logger = logger; 
            _queryService = queryService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<DataCollection<CategoriaDTO>> GetAll(int page = 1, int take = 10, string ids = null)
        {
            try
            {
                IEnumerable<Guid>? categorias = null;
                if (!string.IsNullOrEmpty(ids))
                {
                    categorias = (IEnumerable<Guid>?)ids.Split(',').Select(x => Convert.ToInt32(x));
                }

                return await _queryService.GetAllAsync(page, take, categorias);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }


        [HttpGet("{id}")]
        public async Task<CategoriaDTO> Get(Guid id)
        {
            try
            {
                return await _queryService.GetAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoriaCreateCommand command)
        {
            await _mediator.Publish(command);
            return Ok();
        }

    }
}
