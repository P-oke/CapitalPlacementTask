using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacementTask.Application.DTOs.QuestionDTOs.DropDownDTOs
{
    public class CreateDropDownDTO
    {
        [Required]
        public string Question { get; set; }
        [Required]
        public string Choice { get; set; }
    }
}
