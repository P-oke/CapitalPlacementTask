using CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.ApplicationDTOs;
using CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.EducationDTOs;
using CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.WorkExperienceDTOs;
using CapitalPlacementTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.ProfileDTOs
{
    public class ProfileDTO
    {
        public Guid Id { get; set; }
        public string Resume { get; set; }
        public List<EducationDTO> EducationDTO { get; set; } = new List<EducationDTO>();
        public List<WorkExperienceDTO> WorkExperienceDTO { get; set; } = new List<WorkExperienceDTO>();
        public DateTime CreatedOn { get; set; }

        public static implicit operator ProfileDTO(Profile model)
        {
            return model is null ? null : new ProfileDTO
            {
                Id = model.Id,
                Resume = model.Resume,
                EducationDTO = model.Education.Select(x => (EducationDTO)x).ToList(),
                WorkExperienceDTO = model.WorkExperience.Select(x => (WorkExperienceDTO)x).ToList(),
                CreatedOn = model.CreatedOn,
            };
        }

    }
}
