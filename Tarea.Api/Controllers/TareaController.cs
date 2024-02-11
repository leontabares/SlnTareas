using Common.Collection;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using Tarea.Api.Enums;
using Tarea.Service.EventHandlers.Commands;
using Tarea.Service.Queries.DTOs;
using Tarea.Service.Queries.Interfaces;

namespace Tarea.Api.Controllers
{
    [ApiController]
    [Route("Tarea")]
    public class TareaController : Controller
    {
        private readonly ILogger<TareaController> _logger;
        private readonly ITareaQueryService _queryService;
        private readonly IMediator _mediator;
        static DataResponse<TareaDTO> objResponse;

        public TareaController(ILogger<TareaController> logger, ITareaQueryService queryService, IMediator mediator)
        {
            _logger = logger;
            _queryService = queryService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<DataCollection<TareaDTO>> GetAll(int page = 1, int take = 10, string ids = null)
        {
            DataCollection<TareaDTO> objGetAll = new();
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
                    objGetAll = rta;
                    objGetAll.IdMessage = EnumMessagesResponse.EnumResponse.Ok.GetHashCode().ToString();
                    objGetAll.BodyResponseMessage = EnumMessagesResponse.EnumResponse.Ok.GetDisplayName();
                }
                else
                {
                    objGetAll.IdMessage = EnumMessagesResponse.EnumResponse.NoContent.GetHashCode().ToString();
                    objGetAll.BodyResponseMessage = EnumMessagesResponse.EnumResponse.NoContent.GetDisplayName();                    
                }                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                objGetAll.IdMessage = EnumMessagesResponse.EnumResponse.Err.GetHashCode().ToString();
                objGetAll.BodyResponseMessage = EnumMessagesResponse.EnumResponse.Err.GetDisplayName();
            }

            return objGetAll;
        }


        [HttpGet("{id}")]
        public async Task<DataResponse<TareaDTO>> Get(string id)
        {
            objResponse = new();
            try
            {
                Guid idGuid = Guid.Parse(id);
                var rta = await _queryService.GetAsync(idGuid);
                if (rta is not null)
                {
                    List<TareaDTO> lstTareas = [];
                    TareaDTO objTarea = rta;
                    lstTareas.Add(objTarea);
                    ResponseMessageOk(ref objResponse);
                    objResponse.Items = lstTareas;
                }
                else
                {
                    ResponseMessageNoContent(ref objResponse);
                    objResponse.Items = null;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                ErrorMessage(ref objResponse);
            }
            return objResponse;
        }

        [HttpPost]
        public async Task<DataResponse<TareaDTO>> Create(TareaCreateCommand command)
        {            
            objResponse = new();
            try
            {
                await _mediator.Publish(command);
                ResponseMessageOk(ref objResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                ErrorMessage(ref objResponse);
            }
            return objResponse;
        }

        [HttpPut]
        public async Task<DataResponse<TareaDTO>> Update(TareaUpdateCommand command)
        {
            objResponse = new();
            try
            {
                await _mediator.Publish(command);
                ResponseMessageOk(ref objResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                ErrorMessage(ref objResponse);
            }
            return objResponse;
        }

        [HttpDelete]
        public async Task<DataResponse<TareaDTO>> Delete(TareaDeleteCommand command)
        {
            objResponse = new();
            try
            {
                await _mediator.Publish(command);
                ResponseMessageOk(ref objResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                ErrorMessage(ref objResponse);
            }
            return objResponse;
        }

        #region Metodos privados
        private static void ResponseMessageOk(ref DataResponse<TareaDTO> objResp)
        {
            objResp.IdMessage = EnumMessagesResponse.EnumResponse.Ok.GetHashCode().ToString();
            objResp.BodyResponseMessage = EnumMessagesResponse.EnumResponse.Ok.GetDisplayName();
        }

        private static void ResponseMessageNoContent(ref DataResponse<TareaDTO> objResp)
        {
            objResp.IdMessage = EnumMessagesResponse.EnumResponse.NoContent.GetHashCode().ToString();
            objResp.BodyResponseMessage = EnumMessagesResponse.EnumResponse.NoContent.GetDisplayName();
        }

        private static void ErrorMessage(ref DataResponse<TareaDTO> objResp)
        {
            objResp.IdMessage = EnumMessagesResponse.EnumResponse.Err.GetHashCode().ToString();
            objResp.BodyResponseMessage = EnumMessagesResponse.EnumResponse.Err.GetDisplayName();
        }
        #endregion
    }
}
