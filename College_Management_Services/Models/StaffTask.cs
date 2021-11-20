using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace College_Management_Services.Models
{
    [Table("StaffTasks")]
    public class StaffTask
    {
        [Key]
        public int TaskId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
    }
}
