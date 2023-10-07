using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacementTask.Application.DTOs.QuestionDTOs.YesOrNoDTO
{
    public class CreateYesOrNoDTO
    {
        [Required]
        public string Question { get; set; }
        public bool DisqualifyWrongCandidateAnswer { get; set; }

    }
}
