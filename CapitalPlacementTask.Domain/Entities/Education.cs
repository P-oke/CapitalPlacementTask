namespace CapitalPlacementTask.Domain.Entities
{
    public class Education : BaseEntity<Guid>
    {
        public string School { get; set; }
        public string Degree { get; set; }
        public string CourseName { get; set; }
        public string SchoolLocation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool CurrentlyStudyingThere{ get; set; }
        public Profile Profile { get; set; }
        public Guid ProfileId { get; set; }
    }
}
