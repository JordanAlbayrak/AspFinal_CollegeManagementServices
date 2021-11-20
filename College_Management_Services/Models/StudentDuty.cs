using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace College_Management_Services.Models
{
    [Table("StudentDuty")]
    public class StudentDuty
    {
        [Key]
        public int DutyId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
