﻿using CapitalPlacementTask.Application.DTOs.WorkFlowDTOs.VideoInterviewDTOs;
using CapitalPlacementTask.Domain.Entities;
using CapitalPlacementTask.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacementTask.Application.DTOs.WorkFlowDTOs
{
    public class CreateWorkFlowDTO
    {
        public string StageName { get; set; }
        public WorkflowType WorkflowType { get; set; }
        public StageType StageType { get; set; }
        public CreateVideoInterviewDTO CreateVideoInterview { get; set; }
        public Guid VideoInterviewId { get; set; }
    }
}
