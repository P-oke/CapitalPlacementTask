using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.WorkExperienceDTOs
{
    public class UpdateWorkExperienceDTO
    {
        public string Company { get; set; }
        public string Title { get; set; }
        public string LocationOfWork { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool CurrentlyWorkThere { get; set; }
    }
}
