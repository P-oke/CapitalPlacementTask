using System.ComponentModel.DataAnnotations;

namespace CapitalPlacementTask.Application.DTOs.PreviewDTOs
{
    public class CreatePreviewDTO
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public string ProgramSkillSet { get; set; }
        [Required]
        public string ProgramBenefit { get; set; }
        [Required]
        public string ApplicationCriteria { get; set; }
    }
}
