using Microsoft.AspNetCore.Identity;
using personaltest.Areas.Entities;
using personaltest.ViewModels;

namespace personaltest.Helpers
{
    public interface IUserHelper
    {
        Task<UserTest> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(UserTest user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(UserTest user, string roleName);

        Task<bool> IsUserInRoleAsync(UserTest user, string roleName);

        Task<string> GenerateEmailConfirmationTokenAsync(UserTest user);

        Task<IdentityResult> ConfirmEmailAsync(UserTest user, string token);

        Task<SignInResult> ValidatePasswordAsync(UserTest user, string password);

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task<UserTest> GetUserByIdAsync(string userId);
        Task<string> GeneratePasswordResetTokenAsync(UserTest user);

        Task<IdentityResult> ResetPasswordAsync(UserTest user, string token, string password);

        Task<IdentityResult> ChangePasswordAsync(UserTest user, string oldPassword, string newPassword);
    }
}