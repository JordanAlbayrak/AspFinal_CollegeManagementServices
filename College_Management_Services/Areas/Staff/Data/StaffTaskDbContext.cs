using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using College_Management_Services.Models;

namespace College_Management_Services.Data
{
    public class StaffTaskDbContext : DbContext
    {
        public StaffTaskDbContext (DbContextOptions<StaffTaskDbContext> options)
            : base(options)
        {
        }

        public DbSet<College_Management_Services.Models.StaffTask> StaffTask { get; set; }
    }
}
