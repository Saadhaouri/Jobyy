using System.ComponentModel.DataAnnotations;

namespace Joby.Domain.Models
{
    public class Education
    {

        public string EducationKey { get; set; }
        public string Degree { get; set; }
        public string Major { get; set; }
        public string School { get; set; }
        public DateTime GraduationDate { get; set; }

    }
}
