using Pickup.Application.Models.Identity;
using System;

namespace Pickup.Application.Models.Chat
{
    public partial class ChatHistory
    {
        public long Id { get; set; }
        public string FromUserId { get; set; }
        public string ToUserId { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool isReaded { get; set; } = false;
        public virtual BlazorHeroUser FromUser { get; set; }
        public virtual BlazorHeroUser ToUser { get; set; }
    }
}