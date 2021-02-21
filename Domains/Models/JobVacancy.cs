using FatecMauaJobNewsletter.Domains.Utils;
using System;
using System.ComponentModel.DataAnnotations;

namespace FatecMauaJobNewsletter.Domains.Models
{
    public class JobVacancy : BaseEntity
    {
        [Required]
        [Display(Name = "Vaga")]
        [MaxLength(50, ErrorMessage = ErrorMessages.MaxLengthError)]
        public string JobName { get; set; }

        [Required]
        [Display(Name = "Descrição da vaga")]
        [MaxLength(1000, ErrorMessage = ErrorMessages.MaxLengthError)]
        public string JobDescription { get; set; }

        [Required]
        [Display(Name = "Área de atuação")]
        [MaxLength(50, ErrorMessage = ErrorMessages.MaxLengthError)]
        public string JobArea { get; set; }

        [Display(Name = "Telefone/Celular")]
        [MaxLength(11, ErrorMessage = ErrorMessages.MaxLengthError)]
        public string PhoneNumber { get; set; }

        public DateTime? StartDateJobVacancy { get; set; }

        public DateTime? EndDateJobVacancy { get; set; }

        [Display(Name = "CEP")]
        [MaxLength(8, ErrorMessage = ErrorMessages.MaxLengthError)]
        public string ZipCode { get; set; }

        [Display(Name = "Logrodouro")]
        [MaxLength(1000, ErrorMessage = ErrorMessages.MaxLengthError)]
        public string Address { get; set; }

        [Display(Name = "Cidade")]
        [MaxLength(200, ErrorMessage = ErrorMessages.MaxLengthError)]
        public string City { get; set; }

        [Display(Name = "UF")]
        [MaxLength(2, ErrorMessage = ErrorMessages.MaxLengthError)]
        public string State { get; set; }

        [Display(Name = "Número")]
        [MaxLength(6, ErrorMessage = ErrorMessages.MaxLengthError)]
        public string CompanyNumber { get; set; }

        [Display(Name = "Responsável pela vaga")]
        [MaxLength(200, ErrorMessage = ErrorMessages.MaxLengthError)]
        public string JobResponsible { get; set; }

        public decimal? Salary { get; set; }
    }
}
