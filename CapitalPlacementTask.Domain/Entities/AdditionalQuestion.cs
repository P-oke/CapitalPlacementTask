namespace CapitalPlacementTask.Domain.Entities
{
    public class AdditionalQuestion : BaseEntity<Guid>
    {
        public string AboutSelf { get; set; }
        public string YearOfGraduation { get; set; }
    }
}
