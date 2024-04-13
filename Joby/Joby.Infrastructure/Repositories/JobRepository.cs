using Joby.Infrastructure.Data;
using JObyy.Core.Application.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;
using Joby.Domain.Models;


namespace Infrastructure.Repositories
{
    public class JobRepository : IJobRepository, IDisposable
    {
        private JobyDbContext context;

        public JobRepository(JobyDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Job> GetJobs()
        {
            return context.Jobs.ToList();
        }

        public Job GetJobById(string jobId)
        {
            return context.Jobs.Find(jobId);
        }

        public void InsertJob(Job job)
        {
            // Assign a new string if one is not provided
         

            context.Jobs.Add(job);
        }

        public void DeleteJob(string jobId)
        {
            Job job = context.Jobs.Find(jobId);
            if (job != null)
            {
                context.Jobs.Remove(job);
            }
        }

        public void UpdateJob(Job job)
        {
            context.Entry(job).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}
