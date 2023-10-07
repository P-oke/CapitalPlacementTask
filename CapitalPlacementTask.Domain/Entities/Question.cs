using CapitalPlacementTask.Domain.Enum;

namespace CapitalPlacementTask.Domain.Entities
{
    public class Question : BaseEntity<Guid>
    {
        public QuestionType QuestionType { get; set; }
        public ParagraphQuestion ParagraphQuestion { get; set; }
        public Guid? ParagraphQuestionId { get; set; }

        public MultipleChoice MultipleChoice { get; set; }
        public Guid MultipleChoiceId { get; set; }

        public DropDown DropDown { get; set; }
        public Guid DropDownId { get; set; }

        public YesOrNo YesOrNo { get; set; }
        public Guid YesOrNoId { get; set; }

    }
}
