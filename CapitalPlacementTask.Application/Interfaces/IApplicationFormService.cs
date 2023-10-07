using CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.ApplicationDTOs;
using CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.ApplicationDTOs.ApplicationDTOs;
using CapitalPlacementTask.Application.DTOs.ProgramDTOs;
using CapitalPlacementTask.Application.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacementTask.Application.Interfaces
{
    public interface IApplicationFormService
    {
        Task<ResultModel<ApplicationFormDTO>> GetApplicationForm(Guid id); 
        //Task<ResultModel<List<ProgramDetailDTO>>> AllProgramDetails();
        Task<ResultModel<bool>> CreateApplicationForm(CreateApplicationFormDTO model);
        Task<ResultModel<bool>> UpdateApplicationForm(UpdateApplicationFormDTO model, Guid id);
        Task<ResultModel<bool>> DeleteApplicationForm(Guid id); 
    }
}
