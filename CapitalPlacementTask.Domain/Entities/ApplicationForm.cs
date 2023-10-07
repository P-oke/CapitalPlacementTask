namespace CapitalPlacementTask.Domain.Entities
{
    public class ApplicationForm : BaseEntity<Guid>
    {        
        public string CoverImage { get; set; }
        public PersonalInformation PersonalInformation { get; set; }
        public Guid PersonalInformationId { get; set; }
        public Profile Profile { get; set; }
        public Guid ProfileId { get; set; }
        public ProgramDetail ProgramDetail { get; set; }
        public Guid ProgramDetailId { get; set; }

    }
}
