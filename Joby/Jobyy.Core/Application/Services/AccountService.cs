using AutoMapper;
using Joby.Domain.Models;
using Jobyy.Core.Application.Dto_s;
using Jobyy.Core.Application.Interfaces.IRepository;
using Jobyy.Core.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Identity;

namespace Jobyy.Core.Application.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IMapper _mapper;

    // Optionally, you can add more complex business logic here
    public async Task<IdentityResult> ChangePasswordAsync(string userId, string currentPassword, string newPassword)
    {
        // Check if the new password is the same as the current password
        if (currentPassword == newPassword)
        {
            return IdentityResult.Failed(new IdentityError { Description = "New password must be different from the current password." });
        }

        // Call the repository to change the password
        return await _accountRepository.ChangePasswordAsync(userId, currentPassword, newPassword);
    }

    public async Task<string> LoginAsync(SignInUserDto signInUser)
    {
        // Business logic for user authentication
        var userEntity = _mapper.Map<SignInUser>(signInUser);
        // Call the repository to generate and return the JWT token
        return await _accountRepository.LoginAsync(userEntity);
    }

    public async Task<IdentityResult> SignUpAsync(SignUpUserDto signUpUser)
    {
        if (string.IsNullOrEmpty(signUpUser.Email) || string.IsNullOrEmpty(signUpUser.Password))
        {
            // Invalid input, return a result indicating failure
            return IdentityResult.Failed(new IdentityError { Description = "Username and password are required." });
        }
        // You can use AutoMapper to map SignUpUserDto to your actual user entity
        var userEntity = _mapper.Map<SignUpUser>(signUpUser);

        // Call the repository to perform the actual sign-up
        return await _accountRepository.SignUpAsync(userEntity);
    }
}

