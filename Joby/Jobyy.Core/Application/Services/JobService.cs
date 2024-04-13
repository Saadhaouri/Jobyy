using AutoMapper;
using Joby.Core.Application.Interfaces.IServices;
using Joby.Domain.Models;
using JObyy.Core.Application.Dto_s;
using JObyy.Core.Application.Interfaces.IRepository;

public class JobService : IJobService
{
    private readonly IJobRepository _jobRepository;
    private readonly IMapper _mapper; // Assuming you are using AutoMapper for mapping between DTO and Model

    public JobService(IJobRepository jobRepository, IMapper mapper)
    {
        _jobRepository = jobRepository;
        _mapper = mapper;
    }

    public IEnumerable<JobDto> GetJobs()
    {
        var jobs = _jobRepository.GetJobs();
        return _mapper.Map<IEnumerable<JobDto>>(jobs);
    }

    public JobDto GetJobById(string jobId)
    {
        var job = _jobRepository.GetJobById(jobId);
        return _mapper.Map<JobDto>(job);
    }

    public void AddJob(JobDto job)
    {
        var jobModel = _mapper.Map<Job>(job);
        // You can perform additional business logic/validation here before saving
        _jobRepository.InsertJob(jobModel);
        _jobRepository.Save();
    }

    public void UpdateJob(JobDto job)
    {
        var jobModel = _mapper.Map<Job>(job);
        // You can perform additional business logic/validation here before updating
        _jobRepository.UpdateJob(jobModel);
        _jobRepository.Save();
    }

    public void DeleteJob(string jobId)
    {
        // You can perform additional business logic/validation here before deleting
        _jobRepository.DeleteJob(jobId);
        _jobRepository.Save();
    }
}
