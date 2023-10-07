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
        public IFormFile CoverImage { get; set; }
        public List<UpdatePersonalInformationDTO> UpdatePersonalInformationDTO { get; set; } = new();
        public List<UpdateProfileDTO> UpdateProfileDTO { get; set; } = new();
    }
}
