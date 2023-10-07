using CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.PersonalInformationDTOs;
using CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.ProfileDTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.ApplicationDTOs
{
    public class UpdateApplicationFormDTO
    {
        public Guid ProgramDetailId { get; set; }
        public Guid PersonalInformationId { get; set; } 
        public Guid ProfileId { get; set; }
        public IFormFile CoverImage { get; set; }
        public UpdatePersonalInformationDTO UpdatePersonalInformationDTO { get; set; }
        public UpdateProfileDTO UpdateProfileDTO { get; set; }
    }
}
