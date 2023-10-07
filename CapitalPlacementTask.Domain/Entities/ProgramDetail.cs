namespace CapitalPlacementTask.Domain.Entities
{
    public class ProgramDetail : BaseEntity<Guid> 
    {
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
    }
}
