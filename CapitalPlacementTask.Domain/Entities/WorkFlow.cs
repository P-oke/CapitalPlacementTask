using CapitalPlacementTask.Domain.Enum;

namespace CapitalPlacementTask.Domain.Entities
{
    public class WorkFlow : BaseEntity<Guid>
    {
        public string StageName { get; set; }
        public WorkflowType WorkflowType { get; set; }
        public StageType StageType { get; set; }
        public VideoInterview VideoInterview { get; set; }
        public Guid VideoInterviewId { get; set; }
    }
}
