using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using College_Management_Services.Models;

namespace College_Management_Services.Data
{
    public class StudentDutyContext : DbContext
    {
        public StudentDutyContext (DbContextOptions<StudentDutyContext> options)
            : base(options)
        {
        }

        public DbSet<College_Management_Services.Models.StudentDuty> StudentDuty { get; set; }
    }
}
