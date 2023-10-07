using CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.ApplicationDTOs;
using CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.ApplicationDTOs.ApplicationDTOs;
using CapitalPlacementTask.Application.DTOs.ProgramDTOs;
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
    public class ApplicationFormController : BaseController
    {
        private readonly IApplicationFormService _applicationFormService;

        public ApplicationFormController(IApplicationFormService applicationFormService)
        {
            _applicationFormService = applicationFormService;
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResultModel<ApplicationFormDTO>), 200)]
        public async Task<IActionResult> GetApplicationForm(Guid id)
        {

            try
            {
                var result = await _applicationFormService.GetApplicationForm(id);

                return ApiResponse(message: result.Message, codes: result.ApiResponseCode, data: result.Data, errors: result.ErrorMessages.ToArray());

            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResultModel<bool>), 200)]
        public async Task<IActionResult> CreateApplicationForm([FromBody] CreateApplicationFormDTO model)
        {
            try
            {
                var result = await _applicationFormService.CreateApplicationForm(model);

                return ApiResponse(message: result.Message, codes: result.ApiResponseCode, data: result.Data, errors: result.ErrorMessages.ToArray());

            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ResultModel<bool>), 200)]
        public async Task<IActionResult> UpdateApplicationForm([FromBody] UpdateApplicationFormDTO model, Guid id)
        {
            try
            {
                var result = await _applicationFormService.UpdateApplicationForm(model, id);

                return ApiResponse(message: result.Message, codes: result.ApiResponseCode, data: result.Data, errors: result.ErrorMessages.ToArray());

            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ResultModel<bool>), 200)]
        public async Task<IActionResult> DeleteApplicationForm(Guid id) 
        {

            try
            {
                var result = await _applicationFormService.DeleteApplicationForm(id);

                return ApiResponse(message: result.Message, codes: result.ApiResponseCode, data: result.Data, errors: result.ErrorMessages.ToArray());

            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }
    }
}
