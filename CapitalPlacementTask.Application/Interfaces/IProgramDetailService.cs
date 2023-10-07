
using CapitalPlacementTask.Application.DTOs.ProgramDTOs;
using CapitalPlacementTask.Application.Utils;

namespace CapitalPlacementTask.Application.Interfaces
{
    public interface IProgramDetailService
    {
        Task<ResultModel<ProgramDetailDTO>> GetProgramDetail(Guid id);
        Task<ResultModel<List<ProgramDetailDTO>>> AllProgramDetails();
        Task<ResultModel<bool>> CreateProgramDetail(CreateProgramDTO model);
        Task<ResultModel<bool>> UpdateProgramDetail(UpdateProgramDetailDTO model, Guid id);
        Task<ResultModel<bool>> DeleteProgramDetail(Guid id);
    }
}
