namespace CapitalPlacementTask.Domain.Entities
{
    public class ParagraphQuestion : BaseEntity<Guid>
    {
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
