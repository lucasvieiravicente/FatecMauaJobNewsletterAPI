using FatecMauaJobNewsletter.Domains.Models;
using FatecMauaJobNewsletter.Domains.Models.Request;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FatecMauaJobNewsletter.Services.Interfaces
{
    public interface IJobVacancyService
    {
        Task RegisterJob(JobVacancyRegisterRequest request);

        Task UpdateJob(JobVacancyRegisterRequest request);

        IEnumerable<JobVacancy> GetAllActive();

        JobVacancy FindById(Guid id);
    }
}
