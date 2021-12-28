using Microsoft.AspNetCore.Identity;
using Pickup.Application.Models.Chat;
using Pickup.Domain.Contracts;
using Pickup.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using static Pickup.Shared.Constants.User.UserConstants;

namespace Pickup.Application.Models.Identity
{
    public class BlazorHeroUser : IdentityUser, IAuditableEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string CreatedBy { get; set; }

        [Column(TypeName = "text")]
        public string ProfilePictureDataUrl { get; set; }

        public DateTime CreatedOn { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime? LastModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
        public bool IsActive { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public UserType UserType { get; set; }
        public virtual ICollection<ChatHistory> ChatHistoryFromUsers { get; set; }
        public virtual ICollection<ChatHistory> ChatHistoryToUsers { get; set; }
        public virtual ICollection<Branch> Branches { get; set; }
        public BlazorHeroUser()
        {
            ChatHistoryFromUsers = new HashSet<ChatHistory>();
            ChatHistoryToUsers = new HashSet<ChatHistory>();
            Branches = new HashSet<Branch>();
        }
    }
}