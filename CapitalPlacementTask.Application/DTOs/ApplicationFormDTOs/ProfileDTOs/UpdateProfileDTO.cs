using CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.CreateWorkExperienceDTOs;
using CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.EducationDTOs;
using CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.WorkExperienceDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.ProfileDTOs
{
    public class UpdateProfileDTO
    {
        public string Company { get; set; }
        public string Title { get; set; }
        public string LocationOfWork { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool CurrentlyWorkThere { get; set; }
        internal List<UpdateEducationDTO> UpdateEducationDTO { get; set; } = new List<UpdateEducationDTO>();
        public List<UpdateWorkExperienceDTO> UpdateWorkExperienceDTO { get; set; } = new List<UpdateWorkExperienceDTO>();
    }
}
