namespace JObyy.Core.Application.Dto_s
{
    public class JobDto
    {
     
        public string JobTitle { get; set; }
        public string CompanyId { get; set; }
        public CompanyDto Company { get; set; }
        public ICollection<PostDto> Posts { get; set; }
        public UserDto Users { get; set; }
    }

}
