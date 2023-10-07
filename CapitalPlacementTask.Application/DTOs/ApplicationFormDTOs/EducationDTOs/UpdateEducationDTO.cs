using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.EducationDTOs
{
    public class UpdateEducationDTO
    {
        public Guid Id { get; set; }
        public string School { get; set; }
        public string Degree { get; set; }
        public string CourseName { get; set; }
        public string SchoolLocation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool CurrentlyStudyingThere { get; set; }
    }
}
