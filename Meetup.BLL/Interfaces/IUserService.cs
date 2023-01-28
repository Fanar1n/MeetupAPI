using Meetup.BLL.Models;
using Meetup.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Meetup.BLL.Interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUserAsync(Register register);

        Task<ApplicationUser> FindByNameAsync(string email);

        Task<IList<string>> GetRolesAsync(ApplicationUser user);

        Task<string> GetUserNameAsync(ApplicationUser user);

        Task<string> GetEmailAsync(ApplicationUser user);

        Task<string> GetUserIdAsync(ApplicationUser user);

        Task<SignInResult> CheckPasswordSignInAsync(ApplicationUser user, string password, bool lockoutOnFailure);
    }
}
