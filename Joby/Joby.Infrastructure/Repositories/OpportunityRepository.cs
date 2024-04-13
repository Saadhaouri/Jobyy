using Joby.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using JObyy.Core.Application.Interfaces.IRepository;
using Joby.Domain.Models;


namespace Infrastructure.Repositories
{
    public class OpportunityRepository : IOpportunityRepository, IDisposable
    {
        private JobyDbContext context;

        public OpportunityRepository(JobyDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Opportunity> GetOpportunities()
        {
            return context.Opportunity.Include(e => e.Company).ToList();
        }

        public Opportunity GetOpportunityById(Guid opportunityId)
        {
            return context.Opportunity.Include(e => e.Company).FirstOrDefault(e => e.Id == opportunityId) ?? throw new InvalidOperationException();
        }

        public void InsertOpportunity(Opportunity opportunity)
        {
            // Assign a new string if one is not provided
          

            context.Opportunity.Add(opportunity);
        }

        public void DeleteOpportunity(Guid opportunityId)
        {
            Opportunity opportunity = context.Opportunity.Find(opportunityId) ?? throw new InvalidOperationException(" Opportonity not found ");
            if (opportunity != null)
            {
                context.Opportunity.Remove(opportunity);
            }
        }

        public void UpdateOpportunity(Opportunity opportunity)
        {
            context.Entry(opportunity).State = EntityState.Modified;
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
