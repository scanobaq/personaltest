using Microsoft.AspNetCore.Identity;
using personaltest.Areas.Entities;
using personaltest.ViewModels;

namespace personaltest.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly UserManager<UserTest> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<UserTest> _signInManager;

        public UserHelper(
            UserManager<UserTest> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<UserTest> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> AddUserAsync(UserTest user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task AddUserToRoleAsync(UserTest user, string roleName)
        {
            await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task CheckRoleAsync(string roleName)
        {
            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName
                });
            }
        }

        public async Task<UserTest> GetUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user;
        }

        public async Task<bool> IsUserInRoleAsync(UserTest user, string roleName)
        {
            return await _userManager.IsInRoleAsync(user, roleName);

        }

        public async Task<IdentityResult> ConfirmEmailAsync(UserTest user, string token)
        {
            return await _userManager.ConfirmEmailAsync(user, token);
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(UserTest user)
        {
            return await _userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public async Task<SignInResult> ValidatePasswordAsync(UserTest user, string password)
        {
            return await _signInManager.CheckPasswordSignInAsync(
                user,
                password,
                false);
        }
        public async Task<SignInResult> LoginAsync(LoginViewModel model)
        {
            return await _signInManager.PasswordSignInAsync(
                model.Username,
                model.Password,
                false,
                false);
        }

        public async Task<UserTest> GetUserByIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<string> GeneratePasswordResetTokenAsync(UserTest user)
        {
            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public async Task<IdentityResult> ResetPasswordAsync(UserTest user, string token, string password)
        {
            return await _userManager.ResetPasswordAsync(user, token, password);
        }
        public async Task<IdentityResult> ChangePasswordAsync(UserTest user, string oldPassword, string newPassword)
        {
            return await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
        }
    }
}