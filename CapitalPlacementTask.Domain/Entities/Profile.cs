namespace CapitalPlacementTask.Domain.Entities
{
    public class Profile : BaseEntity<Guid>
    {
        public string Resume { get; set; }
        public List<Education> Education { get; set; } = new List<Education>();
        public List<WorkExperience> WorkExperience { get; set; } = new List<WorkExperience>();
    }
}
