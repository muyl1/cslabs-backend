﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CSLabsBackend.Models.Enums.UserType;
using CSLabsBackend.Util;
using Microsoft.EntityFrameworkCore;

namespace CSLabsBackend.Models
{
    public class User : ITrackable
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string FirstName { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        public string MiddleName { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string LastName { get; set; }
        
        [NotMapped]
        public string Token { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string SchoolEmail { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(45)")]
        public string PersonalEmail { get; set; }
        
        public int? GraduationYear { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(45)")]
        public string UserType { get; set; } = Guest;

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy hh:mm tt}")]
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        public string CardCodeHash { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy hh:mm tt}")]
        public DateTime? TerminationDate { get; set; }

        public static void OnModelCreating(ModelBuilder builder)
        {
            builder.TimeStamps<User>();
            builder.Unique<User>(u => u.SchoolEmail);
            builder.Unique<User>(u => u.PersonalEmail);
            builder.Unique<User>(u => u.CardCodeHash);
        }
    }
}
