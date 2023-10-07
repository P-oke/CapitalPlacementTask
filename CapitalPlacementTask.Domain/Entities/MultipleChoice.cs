namespace CapitalPlacementTask.Domain.Entities
{
    public class MultipleChoice : BaseEntity<Guid>
    {
        public string Question { get; set; }
        public string Choice { get; set; }
        public int MaxChoiceAllowed { get; set; }
    }
}
