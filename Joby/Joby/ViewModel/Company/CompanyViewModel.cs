namespace Joby.ViewModel.Company
{
    public class CompanyViewModel
    {
        public string UserId { get; set; }
        public string Logo { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string Industry { get; set; }
        public DateTime FoundedDate { get; set; }
        public string Location { get; set; }
        public string Website { get; set; }
        public string LinkedInProfile { get; set; }
        public string TwitterProfile { get; set; }
        public string FacebookProfile { get; set; }
        public CompanyContactViewModel Contact { get; set; }


    }
}
