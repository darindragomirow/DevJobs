using DevJobs.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevJobs.Web.Contracts.Identity
{
    public interface IApplicationUserManager
    {
        Task<User> FindByIdAsync(string userId);

        Task<IdentityResult> CreateAsync(User user, string password);

        Task<string> GetEmailAsync(string userId);

        Task<IdentityResult> SetEmailAsync(string userId, string email);

        Task<IdentityResult> ChangePasswordAsync(string userId, string currentPassword, string newPassword);

        IQueryable<User> Users { get; }
    }
}
