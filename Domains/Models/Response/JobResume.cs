using FatecMauaJobNewsletter.Domains.Models;

namespace FatecMauaJobNewsletter.Models.Response
{
    public class JobResume : BaseEntity
    {
        public string JobName { get; set; }

        public string JobDescription { get; set; }

        public string Salary { get; set; }
    }
}
