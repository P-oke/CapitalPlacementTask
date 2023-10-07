namespace CapitalPlacementTask.Domain.Entities
{
    public class MultipleChoice
    {
        public string Question { get; set; }

        public string Choice { get; set; }
        public int MaxChoiceAllowed { get; set; }
    }
}
