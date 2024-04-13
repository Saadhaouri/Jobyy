using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace Joby.Domain.Models
{
    public class Experience
    {
        public string ExperienceKey { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }


    }
}
