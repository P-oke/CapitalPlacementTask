namespace CapitalPlacementTask.Domain.Entities
{
    public class WorkExperience : BaseEntity<Guid>
    {
        public string Company { get; set; }
        public string Title { get; set; }
        public string LocationOfWork { get; set; }
        public DateTime DateTime { get; set; }
        public bool CurrentlyWorkThere { get; set; }
        public Profile Profile { get; set; }
        public Guid ProfileId { get; set; }
    }
}
