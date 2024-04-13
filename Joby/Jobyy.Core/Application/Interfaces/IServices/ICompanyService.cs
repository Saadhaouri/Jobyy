
using JObyy.Core.Application.Dto_s;

namespace Jobyy.Core.Application.Interfaces.IServices
{
    public interface ICompanyService
    {
        
        public    IEnumerable<CompanyDto> GetCompanies();
        public CompanyDto GetCompanyById(Guid companyId);
        public void AddCompany(CompanyDto company);
        public void UpdateCompany( Guid Id ,  CompanyDto company);
        public void DeleteCompany(Guid companyId);
        

    }
}
