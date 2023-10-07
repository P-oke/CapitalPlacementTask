namespace CapitalPlacementTask.Domain.Entities
{
    public class DropDown : BaseEntity<Guid>
    {
        public string Question { get; set; }
        public string Choice { get; set; }

    }
}
