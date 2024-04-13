
using Joby.Domain.Models;

namespace JObyy.Core.Application.Interfaces.IRepository
{
    public interface IJobRepository : IDisposable
    {
        IEnumerable<Job> GetJobs();
        Job GetJobById(string jobId);
        void InsertJob(Job job);
        void DeleteJob(string jobId);
        void UpdateJob(Job job);
        void Save();
    }
}
