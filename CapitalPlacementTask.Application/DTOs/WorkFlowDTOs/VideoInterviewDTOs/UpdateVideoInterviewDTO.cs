using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacementTask.Application.DTOs.WorkFlowDTOs.VideoInterviewDTOs
{
    public class UpdateVideoInterviewDTO
    {
        public string Question { get; set; }
        public string VideoDescription { get; set; }
        public int VideoDuration { get; set; }
        public int DeadlineSubmission { get; set; }
    }
}
