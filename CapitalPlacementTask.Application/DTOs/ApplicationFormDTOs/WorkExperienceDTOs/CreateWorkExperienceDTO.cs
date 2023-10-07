using CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.ProfileDTOs;
using System.ComponentModel.DataAnnotations;

namespace CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.CreateWorkExperienceDTOs
{
    public class CreateWorkExperienceDTO
    {
        [Required]
        public string Company { get; set; }
        [Required]
        public string Title { get; set; }
        public string LocationOfWork { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool CurrentlyWorkThere { get; set; }
    }
}
