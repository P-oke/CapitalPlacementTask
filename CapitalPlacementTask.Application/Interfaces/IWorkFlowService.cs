using CapitalPlacementTask.Application.DTOs.ProgramDTOs;
using CapitalPlacementTask.Application.DTOs.WorkFlowDTOs;
using CapitalPlacementTask.Application.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacementTask.Application.Interfaces
{
    public interface IWorkFlowService
    {
        Task<ResultModel<WorkFlowDTO>> GetWorkFlow(Guid id);
        Task<ResultModel<bool>> CreateWorkFlow(CreateWorkFlowDTO model);
        Task<ResultModel<bool>> UpdateWorkFlow(UpdateWorkFlowDTO model, Guid id);
        Task<ResultModel<bool>> DeleteWorkFlow(Guid id);
    }
}
