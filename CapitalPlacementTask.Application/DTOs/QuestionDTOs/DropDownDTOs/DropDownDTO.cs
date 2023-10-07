using CapitalPlacementTask.Application.DTOs.QuestionDTOs.MultipleChoiceDTOs;
using CapitalPlacementTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacementTask.Application.DTOs.QuestionDTOs.DropDownDTOs
{
    public class DropDownDTO
    {
        public Guid Id { get; set; }
        public string Question { get; set; }
        public string Choice { get; set; }
        public DateTime CreatedOn { get; set; }


        public static implicit operator DropDownDTO(DropDown model)
        {
            return model is null ? null : new DropDownDTO
            {
                Id = model.Id,
                Question = model.Question,
                Choice = model.Choice,
                CreatedOn = model.CreatedOn,
            };
        }
    }
}
