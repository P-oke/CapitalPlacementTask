using CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.ApplicationDTOs;
using CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.ProfileDTOs;
using CapitalPlacementTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.EducationDTOs
{
    public class EducationDTO
    {
        public Guid Id { get; set; }
        public string School { get; set; }
        public string Degree { get; set; }
        public string CourseName { get; set; }
        public string SchoolLocation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool CurrentlyStudyingThere { get; set; }
        public ProfileDTO ProfileDTO { get; set; }
        public DateTime CreatedOn { get; set; }


        public static implicit operator EducationDTO(Education model)
        {
            return model is null ? null : new EducationDTO
            {
                Id = model.Id,
                School = model.School,
                Degree = model.Degree,
                CourseName = model.CourseName,
                SchoolLocation = model.SchoolLocation,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                CurrentlyStudyingThere = model.CurrentlyStudyingThere,
                ProfileDTO = model.Profile,
                CreatedOn = model.CreatedOn,
            };
        }
    }
}
