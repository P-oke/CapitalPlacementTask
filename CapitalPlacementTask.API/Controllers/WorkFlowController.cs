using CapitalPlacementTask.Application.DTOs.ProgramDTOs;
using CapitalPlacementTask.Application.DTOs.WorkFlowDTOs;
using CapitalPlacementTask.Application.Interfaces;
using CapitalPlacementTask.Application.Models;
using CapitalPlacementTask.Application.Utils;
using CapitalPlacementTask.Infrastructure.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapitalPlacementTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkFlowController : BaseController
    {
        private readonly IWorkFlowService _workFlowService;

        public WorkFlowController(IWorkFlowService workFlowService)
        {
            _workFlowService = workFlowService;   
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResultModel<WorkFlowDTO>), 200)]
        public async Task<IActionResult> GetWorkFlow(Guid id)
        {

            try
            {
                var result = await _workFlowService.GetWorkFlow(id);

                return ApiResponse(message: result.Message, codes: result.ApiResponseCode, data: result.Data, errors: result.ErrorMessages.ToArray());

            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }


        [HttpPost]
        [ProducesResponseType(typeof(ResultModel<bool>), 200)]
        public async Task<IActionResult> CreateWorkFlow([FromBody] CreateWorkFlowDTO model)
        {
            try
            {
                var result = await _workFlowService.CreateWorkFlow(model);

                return ApiResponse(message: result.Message, codes: result.ApiResponseCode, data: result.Data, errors: result.ErrorMessages.ToArray());

            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ResultModel<bool>), 200)]
        public async Task<IActionResult> UpdateWorkFlow([FromBody] UpdateWorkFlowDTO model, Guid id)
        {
            try
            {
                var result = await _workFlowService.UpdateWorkFlow(model, id);

                return ApiResponse(message: result.Message, codes: result.ApiResponseCode, data: result.Data, errors: result.ErrorMessages.ToArray());

            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ResultModel<bool>), 200)]
        public async Task<IActionResult> DeleteWorkFlow(Guid id)
        {

            try
            {
                var result = await _workFlowService.DeleteWorkFlow(id);

                return ApiResponse(message: result.Message, codes: result.ApiResponseCode, data: result.Data, errors: result.ErrorMessages.ToArray());

            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }
    }
}
