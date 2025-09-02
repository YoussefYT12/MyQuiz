using Microsoft.AspNetCore.Identity;
using MyQuiz.Appliction.Contracts.IServices.IUserService;
using MyQuiz.Dtos.AuthResult;
using MyQuiz.Dtos.RegisterDto;
using MyQuiz.Dtos.UserDto;
using MyQuiz.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuiz.Appliction.Services.PrivilageService
{
    public class UserServicsAsync : IUserServiceAsync
    {
        private readonly UserManager<Priv_User> _userManager;
        private readonly SignInManager<Priv_User> _signInManager;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly RoleManager<Priv_Role> _roleManager;
        public UserServicsAsync(UserManager<Priv_User> userManager, SignInManager<Priv_User> signInManager, ITokenGenerator tokenGenerator, RoleManager<Priv_Role> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenGenerator = tokenGenerator;
            _roleManager = roleManager;
        }



        public async Task<AuthResult> LoginAsync(LoginDto dto)
        {
            var user = await _userManager.FindByNameAsync(dto.UserNameOrEmail)
                     ?? await _userManager.FindByEmailAsync(dto.UserNameOrEmail);

            if (user == null)
            {
                return new AuthResult
                {
                    Success = false,
                    Errors = new List<string> { "Invalid username or email." }
                };
            }

            var passwordValid = await _userManager.CheckPasswordAsync(user, dto.Password);

            if (!passwordValid)
            {
                return new AuthResult
                {
                    Success = false,
                    Errors = new List<string> { "Invalid password." }
                };
            }

            var roles = await _userManager.GetRolesAsync(user);
            var token = _tokenGenerator.GenerateJwtToken(user, roles);

            return new AuthResult
            {
                Success = true,
                Token = token
            };
        }





        public async Task<AuthResult> RegisterAsync(RegisterDto dto)
        {
            var existingUser = await _userManager.FindByNameAsync(dto.UserName)
                              ?? await _userManager.FindByEmailAsync(dto.Email);

            if (existingUser != null)
            {
                return new AuthResult
                {
                    Success = false,
                    Errors = new List<string> { "Username or Email already exists." }
                };
            }

            var newUser = new Priv_User
            {
                UserName = dto.UserName,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                EmailConfirmed = true
            };

            var createResult = await _userManager.CreateAsync(newUser, dto.Password);

            if (!createResult.Succeeded)
            {
                return new AuthResult
                {
                    Success = false,
                    Errors = createResult.Errors.Select(e => e.Description).ToList()
                };
            }

            // Optional: assign role if provided
            if (!string.IsNullOrEmpty(dto.Role))
            {
                var roleExists = await _roleManager.RoleExistsAsync(dto.Role);
                if (roleExists)
                    await _userManager.AddToRoleAsync(newUser, dto.Role);
            }

            var roles = await _userManager.GetRolesAsync(newUser);
            var token = _tokenGenerator.GenerateJwtToken(newUser, roles);

            return new AuthResult
            {
                Success = true,
                Token = token
            };
        }
    }
}
