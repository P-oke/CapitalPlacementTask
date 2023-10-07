using CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.ApplicationDTOs;
using CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.ProfileDTOs;
using CapitalPlacementTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.WorkExperienceDTOs
{
    public class WorkExperienceDTO
    {
        public Guid Id { get; set; }
        public string Company { get; set; }
        public string Title { get; set; }
        public string LocationOfWork { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool CurrentlyWorkThere { get; set; }
        public ProfileDTO ProfileDTO { get; set; }
        public DateTime CreatedOn { get; set; }


        public static implicit operator WorkExperienceDTO(WorkExperience model)
        {
            return model is null ? null : new WorkExperienceDTO
            {
                Id = model.Id,
                Company = model.Company,
                Title = model.Title,
                LocationOfWork = model.LocationOfWork,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                ProfileDTO = model.Profile,
                CreatedOn = model.CreatedOn,
            };
        }
    }
}
