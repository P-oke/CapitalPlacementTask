using CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.CreateWorkExperienceDTOs;
using CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.EducationDTOs;
using Microsoft.AspNetCore.Http;

namespace CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.ProfileDTOs
{
    public class CreateProfileDTO
    {
        public IFormFile Resume { get; set; }
        public List<CreateEducationDTO> CreateEducationDTO { get; set; } = new List<CreateEducationDTO>();
        public List<CreateWorkExperienceDTO> CreateWorkExperienceDTO { get; set; } = new List<CreateWorkExperienceDTO>();
    }
}
