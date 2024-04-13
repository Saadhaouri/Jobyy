namespace JObyy.Core.Application.Dto_s
{
    public class OpportunityDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime Deadline { get; set; }
        public CompanyDto Company { get; set; }


    }
}
