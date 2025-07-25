﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace webapi.Model.DTO;

public class UserDto
{
    public int Id { get; set; }

    [Required]
    public required string UserName { get; set; }
    
    public string? FirstName { get; set; }
    
    public string? LastName { get; set; }
    public required string Email { get; set; }

    [JsonIgnore]
    public bool IsAdmin { get; set; } = false;

}