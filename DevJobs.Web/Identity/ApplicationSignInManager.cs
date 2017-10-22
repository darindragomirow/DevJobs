using DevJobs.Models;
using DevJobs.Web.Contracts;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevJobs.Web.Identity
{

    public class ApplicationSignInManager : SignInManager<User, String>, IApplicationSignInManager
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }
    }
}