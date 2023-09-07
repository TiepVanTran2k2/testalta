using Application.Contracts.Dtos.User;
using Application.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace test_weather.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _iUserService;
    public UserController(IUserService user)
    {
        _iUserService = user;
    }
    [HttpPost("login")]
    public async Task<bool> LoginAsync(LoginDto input)
    {
        return await _iUserService.LoginAsync(input);
    }

    [HttpPost("register")]
    public async Task<bool> CreateAsync(UserDto input)
    {
        return await _iUserService.CreateAsync(input);
    }

    [HttpPost("forgotpass")]
    public async Task<string> ForgotPassAsync(LoginDto input)
    {
        return await _iUserService.ForgotPassAsync(input);
    }
}
