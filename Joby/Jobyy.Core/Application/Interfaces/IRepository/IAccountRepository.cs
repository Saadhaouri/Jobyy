using Joby.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Jobyy.Core.Application.Interfaces.IRepository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(SignUpUser signUpUser);
        Task<string> LoginAsync(SignInUser signInUser);
        Task<IdentityResult> ChangePasswordAsync(string userId, string currentPassword, string newPassword);

    }
}
