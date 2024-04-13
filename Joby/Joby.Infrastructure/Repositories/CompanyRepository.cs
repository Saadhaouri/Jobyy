using Joby.Domain.Models;
using Joby.Infrastructure.Data;
using JObyy.Core.Application.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository, IDisposable
    {
        private JobyDbContext context;

        public CompanyRepository(JobyDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Company> GetCompanies()
        {
            return context.Companies.ToList();
        }

        public Company GetCompanyById(Guid companyId)
        {
            return context.Companies.Find(companyId);

        }

        public void InsertCompany(Company company)
        {
            // Assign a new string if one is not provided
            

            context.Companies.Add(company);
        }

        public void DeleteCompany(Guid companyId)
        {
            Company company = context.Companies.Find(companyId);
            if (company != null)
            {
                context.Companies.Remove(company);
            }
        }

        public void UpdateCompany(Company company)
        {
            context.Entry(company).State = EntityState.Modified;
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
