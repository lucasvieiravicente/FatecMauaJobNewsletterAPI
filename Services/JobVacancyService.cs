using FatecMauaJobNewsletter.Domains.Contexts.Interfaces;
using FatecMauaJobNewsletter.Domains.Models;
using FatecMauaJobNewsletter.Domains.Models.Request;
using FatecMauaJobNewsletter.Services.Interfaces;
using Mapster;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FatecMauaJobNewsletter.Services
{
    public class JobVacancyService : IJobVacancyService
    {
        private readonly IRepository<JobVacancy> _repository;
        public JobVacancyService(IRepository<JobVacancy> repository)
        {
            _repository = repository;
        }

        public async Task RegisterJob(JobVacancyRegisterRequest request)
        {
            var job = request.Adapt<JobVacancy>();
            await _repository.InsertAsync(job);
        }

        public async Task UpdateJob(JobVacancyRegisterRequest request)
        {
            JobVacancy job = _repository.FindById(request.Id);
            request.Adapt(job);
            await _repository.UpdateAsync(job);
        }

        public IEnumerable<JobVacancy> GetAllActive()
        {
            return _repository.GetAllActive();
        }

        public JobVacancy FindById(Guid id)
        {
            return _repository.FindById(id);
        }

    }
}
