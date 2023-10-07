using System.ComponentModel.DataAnnotations;

namespace CapitalPlacementTask.Application.DTOs.ProgramDTOs
{
    public class CreateProgramDTO
    {
        [Required]
        public string ProgramTitle { get; set; }
        public string ProgramSummary { get; set; }
        [Required]
        public string ProgramDescription { get; set; }
        public string RequiredSkills { get; set; }
        public string ProgramBenefits { get; set; }
        public string ApplicationCriteria { get; set; }
        [Required]
        public string ProgramType { get; set; }
        public DateTime ProgramStart { get; set; }
        [Required]
        public DateTime ApplicationOpen { get; set; }
        [Required]
        public DateTime ApplicationClose { get; set; }
        public string Duration { get; set; }
        [Required]
        public string ProgramLocation { get; set; }
        public string MinimumQualifications { get; set; }
        public long NumberOfApplication { get; set; }
    }
}
