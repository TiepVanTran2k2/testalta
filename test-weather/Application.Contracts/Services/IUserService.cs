using Application.Contracts.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Services;
public interface IUserService
{
    Task<bool> CreateAsync(UserDto input);
    Task<bool> LoginAsync(LoginDto input);
    Task<string> ForgotPassAsync(LoginDto input);
}
