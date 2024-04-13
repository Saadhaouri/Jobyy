using AutoMapper;
using Joby.ViewModel.Company;
using Jobyy.Core.Application.Interfaces.IServices;
using JObyy.Core.Application.Dto_s;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class CompanyController : ControllerBase
{
    private readonly ICompanyService _companyService;
    private readonly IMapper _mapper;

    public CompanyController(ICompanyService companyService, IMapper mapper)
    {
        _companyService = companyService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetCompanies()
    {
        var companiesDto = _companyService.GetCompanies();
        var companiesViewModel = _mapper.Map<IEnumerable<CompanyViewModel>>(companiesDto);
        return Ok(companiesViewModel);
    }

    [HttpGet("{companyId}")]
    public IActionResult GetCompanyById(Guid companyId)
    {
        
        var companyDto = _companyService.GetCompanyById(companyId);

        if (companyDto == null)
        {
            return NotFound(); // Or return a specific error response
        }

        var companyViewModel = _mapper.Map<CompanyViewModel>(companyDto);
        return Ok(companyViewModel);
    }

    [HttpPost]
    public IActionResult AddCompany([FromBody] CompanyViewModel companyViewModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Map the CompanyViewModel to CompanyDto
        var companyDto = _mapper.Map<CompanyDto>(companyViewModel);

        // Add the company with the provided CompanyDto
        _companyService.AddCompany(companyDto);

        // Return a response, you might want to customize this based on your needs
        return Ok("Company added successfully");
    }

    [HttpPut("{Id}")]
    public IActionResult UpdateCompany(Guid Id, [FromBody] CompanyViewModel companyViewModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        

        
        _companyService.UpdateCompany( Id , _mapper.Map<CompanyDto>(companyViewModel));

        return Ok(" Company Update Seccufly ");
    }

    [HttpDelete("{companyId}")]
    public IActionResult DeleteCompany(Guid companyId)
    {
        var existingCompanyDto = _companyService.GetCompanyById(companyId);

        if (existingCompanyDto == null)
        {
            return NotFound(); // Or return a specific error response
        }

        _companyService.DeleteCompany(companyId);

        return NoContent();
    }
}
