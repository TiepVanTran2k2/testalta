﻿using Domain.Enums;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class User : BaseEntity
{
    
    [Required]
    public string Name { get;set; }
    [Required]
    public string Email { get;set; }
    [Required]
    public string Password { get;set; }
    [Required]
    public string PhoneNumber { get;set; }
    public Gender Gender { get; set; }
    [Required]
    public DateTime CreatedAt { get;set;} = DateTime.Now;
}
