using CapitalPlacementTask.Application.DTOs.ProgramDTOs;
using CapitalPlacementTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacementTask.Application.DTOs.WorkFlowDTOs.VideoInterviewDTOs
{
    public class VideoInterviewDTO
    {
        public Guid Id { get; set; }
        public string Question { get; set; }
        public string VideoDescription { get; set; }
        public int VideoDuration { get; set; }
        public int DeadlineSubmission { get; set; }
        public DateTime CreatedOn { get; set; }


        public static implicit operator VideoInterviewDTO(VideoInterview model)
        {
            return model is null ? null : new VideoInterviewDTO
            {
                Id = model.Id,
                Question = model.Question,
                VideoDescription = model.VideoDescription,
                VideoDuration = model.VideoDuration,
                DeadlineSubmission = model.DeadlineSubmission,
                CreatedOn = model.CreatedOn,
            };
        }
    }
}
