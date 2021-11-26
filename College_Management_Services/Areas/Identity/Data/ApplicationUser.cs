using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace College_Management_Services.Areas.Identity.Data
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string firstName { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string lastName { get; set; }
    }
}
