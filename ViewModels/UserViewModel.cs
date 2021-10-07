using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWebApp.ViewModels
{
    public class UserViewModel: IdentityUser
    {
        public IFormFile ProfileImg { get; set; }
        public string Profile { get; set; }

    }
}
