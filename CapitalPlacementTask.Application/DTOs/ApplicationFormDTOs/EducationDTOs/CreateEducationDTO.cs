using CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.ProfileDTOs;
using System.ComponentModel.DataAnnotations;

namespace CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.EducationDTOs
{
    public class CreateEducationDTO
    {
        [Required]
        public string School { get; set; }
        [Required]
        public string Degree { get; set; }
        [Required]
        public string CourseName { get; set; }
        [Required]
        public string SchoolLocation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool CurrentlyStudyingThere { get; set; }
    }
}
