

using Joby.ViewModel.Company;

namespace Joby.ViewModel
{
    public class OpportunityDisplayViiewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime Deadline { get; set; } 
        public CompanyViewModel Company { get; set; }   
    }
}
