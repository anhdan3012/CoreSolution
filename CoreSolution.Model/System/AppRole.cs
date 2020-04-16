using Microsoft.AspNetCore.Identity;
using System;

namespace CoreSolution.Models.System
{
    public class AppRole : IdentityRole<Guid>
    {
        public string Description { get; set; }
    }
}
