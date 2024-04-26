﻿using PetApp.Data.Entity.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace PetApp.Data.Entity.Implementations
{
    public class User : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

    }
}