using CapitalPlacementTask.Application.DTOs.PreviewDTOs;
using CapitalPlacementTask.Application.DTOs.ProgramDTOs;
using CapitalPlacementTask.Application.Interfaces;
using CapitalPlacementTask.Application.Models;
using CapitalPlacementTask.Application.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapitalPlacementTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreviewController : BaseController
    {
        private readonly IPreviewService _previewService;

        public PreviewController(IPreviewService previewService)
        {
            _previewService = previewService;
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResultModel<PreviewDTO>), 200)]
        public async Task<IActionResult> GetPreview(Guid id)
        {

            try
            {
                var result = await _previewService.GetPreview(id);

                return ApiResponse(message: result.Message, codes: result.ApiResponseCode, data: result.Data, errors: result.ErrorMessages.ToArray());

            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }


        [HttpPost]
        [ProducesResponseType(typeof(ResultModel<bool>), 200)]
        public async Task<IActionResult> CreatePreview([FromBody] CreatePreviewDTO model)
        {
            try
            {
                var result = await _previewService.CreatePreview(model);

                return ApiResponse(message: result.Message, codes: result.ApiResponseCode, data: result.Data, errors: result.ErrorMessages.ToArray());

            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ResultModel<bool>), 200)]
        public async Task<IActionResult> UpdatePreview([FromBody] UpdatePreviewDTO model, Guid id)
        {
            try
            {
                var result = await _previewService.UpdatePreview(model, id);

                return ApiResponse(message: result.Message, codes: result.ApiResponseCode, data: result.Data, errors: result.ErrorMessages.ToArray());

            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ResultModel<bool>), 200)]
        public async Task<IActionResult> DeletePreview(Guid id)
        {

            try
            {
                var result = await _previewService.DeletePreview(id);

                return ApiResponse(message: result.Message, codes: result.ApiResponseCode, data: result.Data, errors: result.ErrorMessages.ToArray());

            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }
    }
}
