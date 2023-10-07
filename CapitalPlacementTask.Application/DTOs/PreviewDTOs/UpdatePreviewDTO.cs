using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacementTask.Application.DTOs.PreviewDTOs
{
    public class UpdatePreviewDTO
    {
        public string Description { get; set; }
        public string ProgramSkillSet { get; set; }
        public string ProgramBenefit { get; set; }
        public string ApplicationCriteria { get; set; }
    }
}
