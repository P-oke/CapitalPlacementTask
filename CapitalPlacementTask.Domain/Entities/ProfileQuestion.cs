namespace CapitalPlacementTask.Domain.Entities
{
    public class ProfileQuestion : BaseEntity<Guid>
    {
        public Guid ProfileId { get; set; }
        public Profile Profile { get; set; }
        public Question Question { get; set; }
        public Guid QuestionId { get; set; } 

    }
}
