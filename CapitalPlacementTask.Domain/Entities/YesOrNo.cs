namespace CapitalPlacementTask.Domain.Entities
{
    public class YesOrNo : BaseEntity<Guid>
    {
        public string Question { get; set; }
        public bool DisqualifyWrongCandidateAnswer { get; set; } 

    }
}
