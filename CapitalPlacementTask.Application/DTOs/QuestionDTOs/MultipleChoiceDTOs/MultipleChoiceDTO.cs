using CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.ApplicationDTOs;
using CapitalPlacementTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacementTask.Application.DTOs.QuestionDTOs.MultipleChoiceDTOs
{
    public class MultipleChoiceDTO
    {
        public Guid Id { get; set; }
        public string Question { get; set; }
        public string Choice { get; set; }
        public int MaxChoiceAllowed { get; set; }
        public DateTime CreatedOn { get; set; }


        public static implicit operator MultipleChoiceDTO(MultipleChoice model)
        {
            return model is null ? null : new MultipleChoiceDTO
            {
                Id = model.Id,
                Question = model.Question,
                Choice = model.Choice,
                MaxChoiceAllowed = model.MaxChoiceAllowed,
                CreatedOn = model.CreatedOn,
            };
        }
    }
}
