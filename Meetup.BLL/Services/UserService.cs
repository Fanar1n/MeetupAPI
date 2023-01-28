using Meetup.BLL.Interfaces;
using Meetup.BLL.Models;
using Meetup.DAL.EF;
using Meetup.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Meetup.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public Task<SignInResult> CheckPasswordSignInAsync(ApplicationUser user, string password, bool lockoutOnFailure)
            => _signInManager.CheckPasswordSignInAsync(user, password, lockoutOnFailure);

        public Task<IdentityResult> CreateUserAsync(Register register)
        {
            var user = new ApplicationUser { UserName = register.Email, Email = register.Email };
            return _userManager.CreateAsync(user, register.Password);
        }

        public Task<ApplicationUser> FindByNameAsync(string email) => _userManager.FindByNameAsync(email);

        public Task<string> GetEmailAsync(ApplicationUser user) => _userManager.GetEmailAsync(user);

        public Task<IList<string>> GetRolesAsync(ApplicationUser user) => _userManager.GetRolesAsync(user);

        public Task<string> GetUserIdAsync(ApplicationUser user) => _userManager.GetUserIdAsync(user);

        public Task<string> GetUserNameAsync(ApplicationUser user) => _userManager.GetUserNameAsync(user);
    }
}
