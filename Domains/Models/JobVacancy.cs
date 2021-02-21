using System;
using System.ComponentModel.DataAnnotations;

namespace FatecMauaJobNewsletter.Domains.Models
{
    public class JobVacancy : BaseEntity
    {
        [Required]
        public string JobName { get; set; }

        [Required]
        public string JobDescription { get; set; }

        [Required]
        public string JobArea { get; set; }

        public DateTime? StartDateJobVacancy { get; set; }

        public DateTime? EndDateJobVacancy { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string JobResponsible { get; set; }

        public decimal? Salary { get; set; }
    }
}
