using AutoMapper;
using Joby.Domain.Models;
using Jobyy.Core.Application.Interfaces.IServices;
using JObyy.Core.Application.Dto_s;
using JObyy.Core.Application.Interfaces.IRepository;

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _companyRepository;


    private readonly IMapper _mapper;

    public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
    {
        _companyRepository = companyRepository;

        _mapper = mapper;
    }

    public IEnumerable<CompanyDto> GetCompanies()
    {
        var companies = _companyRepository.GetCompanies();
        return _mapper.Map<IEnumerable<CompanyDto>>(companies);
    }

    public CompanyDto GetCompanyById(Guid companyId)
    {
        var company = _companyRepository.GetCompanyById(companyId);
        return _mapper.Map<CompanyDto>(company);
    }

    public void AddCompany(CompanyDto company)
    {
        // Ensure that the company doesn't have an existing CompanyId
      

        // Check if UserId is provided
        if (company.UserId == string.Empty)
        {
            // Handle the situation where UserId is not provided
            throw new InvalidOperationException("UserId is required for adding a new company.");
        }

        // Here you can perform additional business logic or validation related to UserId

        // Insert the company
        var companyModel = _mapper.Map<Company>(company);
        _companyRepository.InsertCompany(companyModel);
        _companyRepository.Save();

        // Add address if provided


        // Add contact if provided

    }


    public void UpdateCompany(Guid Id, CompanyDto company)
    {
                 var companyModel = _companyRepository.GetCompanyById(Id) ?? throw new InvalidOperationException( " Company NotFound ");
        // You can perform additional business logic/validation here before updating
        companyModel.CompanyName = company.CompanyName;

        companyModel.Logo = company.Logo;
        companyModel.Description = company.Description;
        companyModel.Industry = company.Industry;
        companyModel.FoundedDate = company.FoundedDate;
        companyModel.Location = company.Location;
        companyModel.Website = company.Website;
        companyModel.LinkedInProfile = company.LinkedInProfile;
        companyModel.TwitterProfile = company.TwitterProfile;
        companyModel.FacebookProfile = company.FacebookProfile;
        companyModel.Contact = new CompanyContact
        {
            City = company.Contact.City,
            Country = company.Contact.Country,
            Email = company.Contact.Email,
            Phone = company.Contact.Phone
        };

        // Now, companyModel is populated with values from the company object



      //  _companyRepository.UpdateCompany(companyModel);
        _companyRepository.Save();
    }

    public void DeleteCompany(Guid companyId)
    {
        // You can perform additional business logic/validation here before deleting
        _companyRepository.DeleteCompany(companyId);
        _companyRepository.Save();
    }
}
