using JObyy.Core.Application.Dto_s;

namespace Joby.Core.Application.Interfaces.IServices
{
    public interface IJobService
    {
        public IEnumerable<JobDto> GetJobs();
        public JobDto GetJobById(string jobId);
        public void AddJob(JobDto job);
        public void UpdateJob(JobDto job);
        public void DeleteJob(string jobId);
    }

}
