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
        public async Task<IEnumerable<CategoriaDTO>> GetAll(int page = 1, int take = 10, string ids = null)
        {
            IEnumerable<CategoriaDTO> objGetAll;
            try
            {
                IEnumerable<Guid>? categorias = null;
                if (!string.IsNullOrEmpty(ids))
                {
                    categorias = (IEnumerable<Guid>?)ids.Split(',').Select(x => Convert.ToInt32(x));
                }

                var rta = await _queryService.GetAllAsync(page, take, categorias);

                if (rta.Items.Any())
                {
                    objGetAll = rta.Items;
                }
                else
                {
                    objGetAll = null;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                objGetAll = null;
            }

            return objGetAll;
        }


        [HttpGet("{id}")]
        public async Task<CategoriaDTO> Get(Guid id)
        {
            CategoriaDTO objRta = null;
            try
            {
                objRta = await _queryService.GetAsync(id);
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                objRta = null;
            }
            return objRta;

        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoriaCreateCommand command)
        {
            await _mediator.Publish(command);
            return Ok();
        }

    }
}
