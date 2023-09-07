using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Dtos.User;
public class UserDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string PhoneNumber { get; set; }
    public Gender Gender { get; set; }
}
public class LoginDto
{
    public string EmailorPhone { get; set; }
    public string Password { get; set; }
}
