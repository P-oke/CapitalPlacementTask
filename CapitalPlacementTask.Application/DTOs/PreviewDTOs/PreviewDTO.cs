using CapitalPlacementTask.Domain.Entities;

namespace CapitalPlacementTask.Application.DTOs.PreviewDTOs
{
    public class PreviewDTO
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string ProgramSkillSet { get; set; }
        public string ProgramBenefit { get; set; }
        public string ApplicationCriteria { get; set; }
        public DateTime CreatedOn { get; set; }

        public static implicit operator PreviewDTO(Preview model)
        {
            return model is null ? null : new PreviewDTO
            {
                Id = model.Id,
                Description = model.Description,
                ProgramSkillSet = model.ProgramSkillSet,
                ProgramBenefit = model.ProgramBenefit,
                ApplicationCriteria = model.ApplicationCriteria,
                CreatedOn = model.CreatedOn,
            };
    
        }  
    }
}
