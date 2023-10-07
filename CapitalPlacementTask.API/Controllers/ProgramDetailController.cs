using CapitalPlacementTask.Application.DTOs.ProgramDTOs;
using CapitalPlacementTask.Application.Interfaces;
using CapitalPlacementTask.Application.Models;
using CapitalPlacementTask.Application.Utils;
using CapitalPlacementTask.Infrastructure.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos.Serialization.HybridRow;
using System.Reflection;

namespace CapitalPlacementTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramDetailController : BaseController
    {
        private readonly IProgramDetailService _programDetailService;

        public ProgramDetailController(IProgramDetailService programDetailService)
        {
            _programDetailService = programDetailService;
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResultModel<ProgramDetailDTO>), 200)]
        public async Task<IActionResult> GetProgramDetails(Guid id)
        {

            try
            {
                var result = await _programDetailService.GetProgramDetail(id); 

                return ApiResponse(message: result.Message, codes: result.ApiResponseCode, data: result.Data, errors: result.ErrorMessages.ToArray());

            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [HttpGet()]
        [ProducesResponseType(typeof(ResultModel<List<ProgramDetailDTO>>), 200)]
        public async Task<IActionResult> GetAllProgramDetails() 
        {
            try
            {
                var result = await _programDetailService.AllProgramDetails();

                return ApiResponse(message: result.Message, codes: result.ApiResponseCode, data: result.Data, totalCount: result.Data.Count, errors: result.ErrorMessages.ToArray());

            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResultModel<bool>), 200)]
        public async Task<IActionResult> CreateProgramDetails([FromBody] CreateProgramDTO model)
        {
            try
            {
                var result = await _programDetailService.CreateProgramDetail(model);

                return ApiResponse(message: result.Message, codes: result.ApiResponseCode, data: result.Data, errors: result.ErrorMessages.ToArray());

            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ResultModel<bool>), 200)]
        public async Task<IActionResult> UpdateProgramDetails([FromBody] UpdateProgramDetailDTO model, Guid id)
        {
            try
            {
                var result = await _programDetailService.UpdateProgramDetail(model, id);

                return ApiResponse(message: result.Message, codes: result.ApiResponseCode, data: result.Data, errors: result.ErrorMessages.ToArray());

            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ResultModel<bool>), 200)]
        public async Task<IActionResult> DeleteProgramDetails(Guid id) 
        {

            try
            {
                var result = await _programDetailService.DeleteProgramDetail(id);

                return ApiResponse(message: result.Message, codes: result.ApiResponseCode, data: result.Data, errors: result.ErrorMessages.ToArray());

            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }
    }
}
