using System;

namespace FatecMauaJobNewsletter.Domains.Models.Request
{
    public class JobVacancyRegisterRequest
    {
        public Guid Id { get; set; }

        public string JobName { get; set; }

        public string JobDescription { get; set; }

        public string JobArea { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime? StartDateJobVacancy { get; set; }

        public DateTime? EndDateJobVacancy { get; set; }

        public string ZipCode { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }
        
        public string CompanyNumber { get; set; }

        public string JobResponsible { get; set; }

        public decimal? Salary { get; set; }
    }
}
