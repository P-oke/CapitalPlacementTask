using CapitalPlacementTask.Application.DTOs.QuestionDTOs.MultipleChoiceDTOs;
using CapitalPlacementTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacementTask.Application.DTOs.QuestionDTOs.YesOrNoDTO
{
    public class YesOrNoDTO
    {
        public Guid Id { get; set; }
        public string Question { get; set; }
        public bool DisqualifyWrongCandidateAnswer { get; set; }
        public DateTime CreatedOn { get; set; }


        public static implicit operator YesOrNoDTO(YesOrNo model)
        {
            return model is null ? null : new YesOrNoDTO
            {
                Id = model.Id,
                Question = model.Question,
                DisqualifyWrongCandidateAnswer = model.DisqualifyWrongCandidateAnswer,
                CreatedOn = model.CreatedOn,
            };
        }

    }
}
