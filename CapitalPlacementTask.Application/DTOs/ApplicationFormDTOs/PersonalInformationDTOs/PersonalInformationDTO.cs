using CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.ApplicationDTOs;
using CapitalPlacementTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.PersonalInformationDTOs 
{
    public class PersonalInformationDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Nationality { get; set; }
        public string CurrentResidence { get; set; }
        public string IdNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public ApplicationFormDTO ApplicationFormDTO { get; set; }
        public DateTime CreatedOn { get; set; }
        //public List<QuestionDTO> Questions { get; set; } = new List<QuestionDTO>();


        public static implicit operator PersonalInformationDTO(PersonalInformation model)
        {
            return model is null ? null : new PersonalInformationDTO
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Nationality = model.Nationality,
                CurrentResidence = model.CurrentResidence,
                IdNumber = model.IdNumber,
                DateOfBirth = model.DateOfBirth,
                Gender = model.Gender,
                ApplicationFormDTO = model.ApplicationForm,
                CreatedOn = model.CreatedOn
            };
        }
    }
}
