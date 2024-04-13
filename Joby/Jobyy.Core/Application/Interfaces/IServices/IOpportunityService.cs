using JObyy.Core.Application.Dto_s;

namespace Joby.Core.Application.Interfaces.IServices
{
    public interface IOpportunityService
    {
        public IEnumerable<OpportunityDto> GetOpportunities();
        public OpportunityDto GetOpportunityById(Guid opportunityId);
        public void AddOpportunity(OpportunityDto opportunity);
        public void UpdateOpportunity(OpportunityDto opportunity);
        public void DeleteOpportunity(Guid opportunityId);
    }
}
