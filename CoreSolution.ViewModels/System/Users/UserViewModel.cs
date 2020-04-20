using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreSolution.ViewModels.System.Users
{
    public class UserViewModel
    {
        public Guid Id { set; get; }
        public string UserName { set; get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

    }
}
