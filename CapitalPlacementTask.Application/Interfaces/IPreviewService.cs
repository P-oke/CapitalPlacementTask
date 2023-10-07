using CapitalPlacementTask.Application.DTOs.PreviewDTOs;
using CapitalPlacementTask.Application.DTOs.WorkFlowDTOs;
using CapitalPlacementTask.Application.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacementTask.Application.Interfaces
{
    public interface IPreviewService
    {

        Task<ResultModel<PreviewDTO>> GetPreview(Guid id);
        Task<ResultModel<bool>> CreatePreview(CreatePreviewDTO model);
        Task<ResultModel<bool>> UpdatePreview(UpdatePreviewDTO model, Guid id);
        Task<ResultModel<bool>> DeletePreview(Guid id);
    }
}
