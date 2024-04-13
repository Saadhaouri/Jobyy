using Joby.Domain.Models;

namespace JObyy.Core.Application.Interfaces.IRepository
{
    public interface ICompanyRepository : IDisposable
    {
        IEnumerable<Company> GetCompanies();
        Company GetCompanyById(Guid companyId);
        void InsertCompany(Company company);
        void UpdateCompany(Company company);
        void Save();
        void DeleteCompany(Guid companyId);
    }
}
