using AutoMapper;
using Joby.Core.Application.Interfaces.IServices;
using Joby.Domain.Models;
using JObyy.Core.Application.Dto_s;
using JObyy.Core.Application.Interfaces.IRepository;

public class OpportunityService : IOpportunityService
{
    private readonly IOpportunityRepository _opportunityRepository;
    private readonly IMapper _mapper;

    public OpportunityService(IOpportunityRepository opportunityRepository, IMapper mapper)
    {
        _opportunityRepository = opportunityRepository;
        _mapper = mapper;
    }

    public IEnumerable<OpportunityDto> GetOpportunities()
    {
        var opportunities = _opportunityRepository.GetOpportunities();
        return _mapper.Map<IEnumerable<OpportunityDto>>(opportunities);
    }

    public OpportunityDto GetOpportunityById(Guid opportunityId)
    {
        var opportunity = _opportunityRepository.GetOpportunityById(opportunityId);
        return _mapper.Map<OpportunityDto>(opportunity);
    }

    public void AddOpportunity(OpportunityDto opportunity)
    {
        var opportunityModel = _mapper.Map<Opportunity>(opportunity);

        // Example of business logic: Check if the deadline is in the future
        if (opportunity.Deadline < DateTime.Now)
        {
            throw new ApplicationException("The opportunity deadline must be in the future.");
        }

        // You can add more business logic checks as needed

        _opportunityRepository.InsertOpportunity(opportunityModel);
        _opportunityRepository.Save();
    }

    public void UpdateOpportunity(OpportunityDto opportunity)
    {
        var opportunityModel = _mapper.Map<Opportunity>(opportunity);

        // Example of business logic: Check if the deadline is in the future
        if (opportunity.Deadline < DateTime.Now)
        {
            throw new ApplicationException("The opportunity deadline must be in the future.");
        }

        // You can add more business logic checks as needed

        _opportunityRepository.UpdateOpportunity(opportunityModel);
        _opportunityRepository.Save();
    }

    public void DeleteOpportunity(Guid opportunityId)
    {
        // Example of business logic: Check if the opportunity exists before deleting
        var existingOpportunity = _opportunityRepository.GetOpportunityById(opportunityId);
        if (existingOpportunity == null)
        {
            throw new ApplicationException("Opportunity not found for deletion.");
        }

        // You can add more business logic checks as needed

        _opportunityRepository.DeleteOpportunity(opportunityId);
        _opportunityRepository.Save();
    }
}
