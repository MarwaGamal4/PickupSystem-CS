﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pickup.Application.Interfaces.Services;
using Pickup.Application.Models.Chat;
using System;
using System.Threading.Tasks;

namespace Pickup.Server.Controllers.Communication
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ChatsController : ControllerBase
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IChatService _chatService;

        public ChatsController(ICurrentUserService currentUserService, IChatService chatService)
        {
            _currentUserService = currentUserService;
            _chatService = chatService;
        }

        //Get user wise chat history
        [HttpGet("{contactId}")]
        public async Task<IActionResult> GetChatHistoryAsync(string contactId)
        {
            return Ok(await _chatService.GetChatHistoryAsync(_currentUserService.UserId, contactId));
        }

        //get available users - sorted by date of last message if exists
        [HttpGet("users")]
        public async Task<IActionResult> GetChatUsersAsync()
        {
            return Ok(await _chatService.GetChatUsersAsync(_currentUserService.UserId));
        }
        [HttpGet("Mark/{contactId}")]
        public async Task<IActionResult> MarkAsRead(string contactId)
        {
            return Ok(await _chatService.MarkAsRead(_currentUserService.UserId, contactId));
        }
        [HttpGet("MarkAll")]
        public async Task<IActionResult> MarkAllAsRead()
        {
            return Ok(await _chatService.MarkAllAsRead(_currentUserService.UserId));
        }
        //save chat message
        [HttpPost]
        public async Task<IActionResult> SaveMessageAsync(ChatHistory message)
        {
            message.FromUserId = _currentUserService.UserId;
            message.ToUserId = message.ToUserId;
            message.CreatedDate = DateTime.Now;
            return Ok(await _chatService.SaveMessageAsync(message));
        }

        [HttpGet("oldchat")]
        public async Task<IActionResult> GetOldChat()
        {
            return Ok(await _chatService.GetOldMessages(_currentUserService.UserId));
        }
    }
}