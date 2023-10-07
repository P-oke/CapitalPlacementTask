using CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.PersonalInformationDTOs;
using CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.ProfileDTOs;
using Microsoft.AspNetCore.Http;

namespace CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.ApplicationDTOs.ApplicationDTOs
{
    public class CreateApplicationFormDTO
    {
        public IFormFile CoverImage { get; set; }
        public List<CreatePersonalInformationDTO> CreatePersonalInformationDTO { get; set; } = new();
        public List<CreateProfileDTO> CreateProfileDTO { get; set; } = new();
    }
}
