
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Joby.Domain.Models
{
    public class Job
    {
        [Key]
        public Guid Id { get; set; }
        public string JobTitle { get; set; }

        // Foreign keys
        [ForeignKey("CompanyId")]
        public string CompanyId { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }

        // Navigation properties
        public Company Company { get; set; }
        public User Users { get; set; }
        
    }
    }


