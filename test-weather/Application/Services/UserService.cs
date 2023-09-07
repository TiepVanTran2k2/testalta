using Application.Contracts.Dtos.User;
using Application.Contracts.Services;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services;
public class UserService : IUserService
{
    private readonly IUserRepository _iUserRepository;
    private readonly IMapper _iMapper;
    public UserService(IUserRepository userRepository,
                       IMapper mapper)
    {
        _iUserRepository = userRepository;
        _iMapper = mapper;
    }
    public async Task<bool> CreateAsync(UserDto input)
    {
        try
        {
            var user = (await _iUserRepository.GetQueryableAsync()).Where(x => x.Email == input.Email || 
                                                                               x.PhoneNumber == input.PhoneNumber).ToList();
            if(user.Any())
            {
                throw new Exception("User exsit");
            }
            var data = _iMapper.Map<User>(input);
            await _iUserRepository.CreateAsync(data);
            return true;
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }

    public async Task<string> ForgotPassAsync(LoginDto input)
    {
        try
        {
            var user = (await _iUserRepository.GetQueryableAsync()).Where(x => x.Email == input.EmailorPhone ||
                                                                               x.PhoneNumber == input.EmailorPhone).FirstOrDefault();
            if(user != null)
            {
                user.Password = "newpasss";
                await _iUserRepository.UpdateAsync(user);
                return "Pass thay vi send mail";
            }
            throw new Exception("Email or phone number not exsit");
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }

    public async Task<bool> LoginAsync(LoginDto input)
    {
        try
        {
            var user = (await _iUserRepository.GetQueryableAsync()).Where(x => x.Email == input.EmailorPhone ||
                                                                               x.PhoneNumber == input.EmailorPhone &&
                                                                               x.Password == input.Password).FirstOrDefault();
            if(user == null)
            {
                throw new Exception("User not exsit");
            }
            return true;
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }
}
