using Joby.Domain.Models;
using Jobyy.Core.Application.Dto_s;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobyy.Core.Application.Interfaces.IServices
{
    public interface IAccountService
    {
        Task<IdentityResult> SignUpAsync(SignUpUserDto signUpUser);
        Task<string> LoginAsync(SignInUserDto signInUser);
        Task<IdentityResult> ChangePasswordAsync(string userId, string currentPassword, string newPassword);


    }
}
