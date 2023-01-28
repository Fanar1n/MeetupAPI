using AutoMapper;
using Meetup.API.ViewModels.Account;
using Meetup.BLL.Interfaces;
using Meetup.BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Meetup.API.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AccountController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }


        [HttpPost("~/account/register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.FindByNameAsync(model.Email);

                if (user != null)
                {
                    return StatusCode(StatusCodes.Status409Conflict);
                }

                var result = await _userService.CreateUserAsync(_mapper.Map<Register>(model));

                if (result.Succeeded)
                {
                    return Ok();
                }

                AddErrors(result);
            }

            return BadRequest(ModelState);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}
