using CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.PersonalInformationDTOs;
using CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.ProfileDTOs;
using Microsoft.AspNetCore.Http;

namespace CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.ApplicationDTOs.ApplicationDTOs
{
    public class CreateApplicationFormDTO
    {
        public Guid ProgramDetailId { get; set; }
        public IFormFile CoverImage { get; set; }
        public CreatePersonalInformationDTO CreatePersonalInformationDTO { get; set; }
        public CreateProfileDTO CreateProfileDTO { get; set; }
    }
}
