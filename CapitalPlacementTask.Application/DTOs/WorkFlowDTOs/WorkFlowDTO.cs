using CapitalPlacementTask.Application.DTOs.ProgramDTOs;
using CapitalPlacementTask.Application.DTOs.WorkFlowDTOs.VideoInterviewDTOs;
using CapitalPlacementTask.Domain.Entities;
using CapitalPlacementTask.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacementTask.Application.DTOs.WorkFlowDTOs
{
    public class WorkFlowDTO
    {
        public Guid Id { get; set; }
        public string StageName { get; set; }
        public WorkflowType WorkflowType { get; set; }
        public StageType StageType { get; set; }
        public VideoInterviewDTO VideoInterviewDTO { get; set; }
        public Guid VideoInterviewId { get; set; }
        public DateTime CreatedOn { get; set; }


        public static implicit operator WorkFlowDTO(WorkFlow model)
        {
            return model is null ? null : new WorkFlowDTO
            {
                Id = model.Id,
                StageName = model.StageName,
                WorkflowType = model.WorkflowType,
                StageType = model.StageType,
                VideoInterviewDTO = model.VideoInterview,          
                CreatedOn = model.CreatedOn,
            };
        }
    }
}
