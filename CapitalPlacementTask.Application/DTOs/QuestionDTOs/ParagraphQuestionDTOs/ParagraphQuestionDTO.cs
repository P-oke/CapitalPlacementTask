using CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.ApplicationDTOs;
using CapitalPlacementTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacementTask.Application.DTOs.QuestionDTOs.ParagraphQuestionDTOs
{
    public class ParagraphQuestionDTO 
    {
        public Guid Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public DateTime CreatedOn { get; set; }

        public static implicit operator ParagraphQuestionDTO(ParagraphQuestion model)
        {
            return model is null ? null : new ParagraphQuestionDTO
            {
                Id = model.Id,
                Question = model.Question,
                Answer = model.Answer,
                CreatedOn = model.CreatedOn
            };
        }
    }
}
