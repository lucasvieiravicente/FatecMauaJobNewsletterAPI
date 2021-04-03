using FatecMauaJobNewsletter.Domains.Consts;
using FatecMauaJobNewsletter.Domains.Enums;
using Mapster;
using System;
using System.ComponentModel.DataAnnotations;

namespace FatecMauaJobNewsletter.Domains.Models
{
    [AdaptTo("JobResume")]
    public class JobVacancy : BaseEntity
    {
        [Required]
        [MaxLength(50, ErrorMessage = ErrorMessages.MaxLengthError)]
        public string JobName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = ErrorMessages.MaxLengthError)]
        public string JobArea { get; set; }

        [MaxLength(1000, ErrorMessage = ErrorMessages.MaxLengthError)]
        public string JobDescription { get; set; }

        [MaxLength(11, ErrorMessage = ErrorMessages.MaxLengthError)]
        public string ResponsiblePhoneNumber { get; set; }

        public string ResponsibleEmail { get; set; }

        public DateTime? StartDateJobVacancy { get; set; }

        public DateTime? EndDateJobVacancy { get; set; }

        [MaxLength(9, ErrorMessage = ErrorMessages.MaxLengthError)]
        public string ZipCode { get; set; }

        [MaxLength(1000, ErrorMessage = ErrorMessages.MaxLengthError)]
        public string Address { get; set; }

        [MaxLength(200, ErrorMessage = ErrorMessages.MaxLengthError)]
        public string City { get; set; }

        [MaxLength(200, ErrorMessage = ErrorMessages.MaxLengthError)]
        public string Neighborhood { get; set; }

        [MaxLength(2, ErrorMessage = ErrorMessages.MaxLengthError)]
        public string State { get; set; }

        [MaxLength(6, ErrorMessage = ErrorMessages.MaxLengthError)]
        public string CompanyNumber { get; set; }

        [MaxLength(200, ErrorMessage = ErrorMessages.MaxLengthError)]
        public string JobResponsible { get; set; }

        public decimal? Salary { get; set; }

        public AdministrationStep AdministrationStep { get; set; }

        public string AdministrationDescription { get; set; }

        [MaxLength(26)]
        public string UserCreated { get; set; }
    }
}
