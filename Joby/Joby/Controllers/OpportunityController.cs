using AutoMapper;

using Joby.Core.Application.Interfaces.IServices;
using Joby.ViewModel;
using JObyy.Core.Application.Dto_s;
using Microsoft.AspNetCore.Mvc;


[Route("api/[controller]")]
[ApiController]
public class OpportunityController : ControllerBase
{
    private readonly IOpportunityService _opportunityService;
    private readonly IMapper _mapper;

    public OpportunityController(IOpportunityService opportunityService, IMapper mapper)
    {
        _opportunityService = opportunityService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetOpportunities()
    {
        var opportunitiesDto = _opportunityService.GetOpportunities();
        var opportunitiesViewModel = _mapper.Map<IEnumerable<OpportunityDisplayViiewModel>>(opportunitiesDto);
        return Ok(opportunitiesViewModel);
    }

    [HttpGet("{opportunityId}")]
    public IActionResult GetOpportunityById(Guid opportunityId)
    {
        var opportunityDto = _opportunityService.GetOpportunityById(opportunityId);

        if (opportunityDto == null)
        {
            return NotFound(); // Or return a specific error response
        }

        var opportunityViewModel = _mapper.Map<OpportunityDisplayViiewModel>(opportunityDto);
        return Ok(opportunityViewModel);
    }

    [HttpPost]
    public IActionResult AddOpportunity([FromBody] OpportunityViewModel opportunityViewModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Map the OpportunityViewModel to OpportunityDto
        var opportunityDto = _mapper.Map<OpportunityDto>(opportunityViewModel);

        // Add the opportunity with the provided OpportunityDto
        _opportunityService.AddOpportunity(opportunityDto);

        // Return a response, you might want to customize this based on your needs
        return Ok("Opportunity added successfully");
    }

    [HttpPut("{opportunityId}")]
    public IActionResult UpdateOpportunity(Guid opportunityId, [FromBody] OpportunityViewModel opportunityViewModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var existingOpportunityDto = _opportunityService.GetOpportunityById(opportunityId);

        if (existingOpportunityDto == null)
        {
            return NotFound(); // Or return a specific error response
        }

        _mapper.Map(opportunityViewModel, existingOpportunityDto);
        _opportunityService.UpdateOpportunity(existingOpportunityDto);

        return NoContent();
    }

    [HttpDelete("{opportunityId}")]
    public IActionResult DeleteOpportunity(Guid opportunityId)
    {
        var existingOpportunityDto = _opportunityService.GetOpportunityById(opportunityId);

        if (existingOpportunityDto == null)
        {
            return NotFound(); // Or return a specific error response
        }

        _opportunityService.DeleteOpportunity(opportunityId);

        return NoContent();
    }
}
