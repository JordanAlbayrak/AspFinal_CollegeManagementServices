using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using College_Management_Services.Models;

namespace College_Management_Services.Data
{
    public class College_Management_ServicesContext : DbContext
    {
        public College_Management_ServicesContext (DbContextOptions<College_Management_ServicesContext> options)
            : base(options)
        {
        }

        public DbSet<College_Management_Services.Models.StudentDuty> StudentDuties { get; set; }

        public DbSet<College_Management_Services.Models.StaffTask> StaffTask { get; set; }
    }
}
