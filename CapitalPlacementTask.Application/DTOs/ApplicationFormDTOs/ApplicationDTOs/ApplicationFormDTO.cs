using CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.PersonalInformationDTOs;
using CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.ProfileDTOs;
using CapitalPlacementTask.Application.DTOs.ProgramDTOs;
using CapitalPlacementTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.ApplicationDTOs
{
    public class ApplicationFormDTO
    {
        public Guid Id { get; set; }
        public string CoverImage { get; set; }
        public PersonalInformationDTO PersonalInformationDTO { get; set; }
        public ProfileDTO ProfileDTO { get; set; }
        public ProgramDetailDTO ProgramDetailDTO { get; set; }
        public DateTime CreatedOn { get; set; }

        public static implicit operator ApplicationFormDTO(ApplicationForm model)
        {
            return model is null ? null : new ApplicationFormDTO
            {
                Id = model.Id,
                CoverImage = model.CoverImage,
                PersonalInformationDTO = model.PersonalInformation,
                ProfileDTO = model.Profile,
                ProgramDetailDTO = model.ProgramDetail,
                CreatedOn = model.CreatedOn,
            };
        } 
            
    }
}
