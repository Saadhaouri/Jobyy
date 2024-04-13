using Joby.Domain.Models;

namespace JObyy.Core.Application.Interfaces.IRepository
{
    public interface IOpportunityRepository : IDisposable
    {
        IEnumerable<Opportunity> GetOpportunities();
        Opportunity GetOpportunityById(Guid opportunityId);
        void InsertOpportunity(Opportunity opportunity);
        void DeleteOpportunity(Guid opportunityId);
        void UpdateOpportunity(Opportunity opportunity);
        void Save();
    }

}
