
using CapitalPlacementTask.Domain.Entities;

namespace CapitalPlacementTask.Application.DTOs.ProgramDTOs
{
    public class ProgramDetailDTO
    {
        public Guid Id { get; set; }
        public string ProgramTitle { get; set; }
        public string ProgramSummary { get; set; }
        public string ProgramDescription { get; set; }
        public string RequiredSkills { get; set; }
        public string ProgramBenefits { get; set; }
        public string ApplicationCriteria { get; set; }
        public string ProgramType { get; set; }
        public DateTime ProgramStart { get; set; }
        public DateTime ApplicationOpen { get; set; }
        public string Duration { get; set; }
        public string ProgramLocation { get; set; }
        public string MinimumQualifications { get; set; }
        public long NumberOfApplication { get; set; }
        public DateTime CreatedOn { get; set; }

        public static implicit operator ProgramDetailDTO(ProgramDetail model)
        {
            return model is null ? null : new ProgramDetailDTO
            {
                Id = model.Id,
                ProgramTitle = model.ProgramTitle,
                ProgramSummary = model.ProgramSummary,
                ProgramDescription = model.ProgramDescription,
                RequiredSkills = model.RequiredSkills,
                ProgramBenefits = model.ProgramBenefits,
                ApplicationCriteria = model.ApplicationCriteria,
                ProgramType = model.ProgramType,
                ProgramStart = model.ProgramStart,
                ApplicationOpen = model.ApplicationOpen,
                Duration = model.Duration,
                ProgramLocation = model.ProgramLocation,
                MinimumQualifications = model.MinimumQualifications,
                NumberOfApplication = model.NumberOfApplication,
                CreatedOn = model.CreatedOn,
            };
        }
    }
}
