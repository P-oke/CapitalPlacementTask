namespace CapitalPlacementTask.Domain.Entities
{
    public class PersonalInformation : BaseEntity<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Nationality { get; set; }
        public string CurrentResidence { get; set; }
        public string IdNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public ApplicationForm ApplicationForm { get; set; }
        public Guid ApplicationFormId { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();
    }
}
