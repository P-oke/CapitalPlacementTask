namespace CapitalPlacementTask.Domain.Entities
{
    public class Preview : BaseEntity<Guid>
    {
        public string Description { get; set; }
        public string ProgramSkillSet { get; set; }
        public string ProgramBenefit { get; set; }
        public string ApplicationCriteria { get; set; } 
    }
}
