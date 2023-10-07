namespace CapitalPlacementTask.Domain.Entities
{
    public class VideoInterview : BaseEntity<Guid>
    {
        public string Question { get; set; }
        public string VideoDescription { get; set; }
        public int VideoDuration { get; set; } 
        public int DeadlineSubmission { get; set; } 
    }
}
