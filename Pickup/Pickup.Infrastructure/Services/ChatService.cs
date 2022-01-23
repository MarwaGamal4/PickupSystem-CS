using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Pickup.Application.Exceptions;
using Pickup.Application.Interfaces.Services;
using Pickup.Application.Interfaces.Services.Identity;
using Pickup.Application.Models.Chat;
using Pickup.Application.Responses.Identity;
using Pickup.Infrastructure.Contexts;
using Pickup.Shared.Wrapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pickup.Infrastructure.Services
{
    public class ChatService : IChatService
    {
        private readonly BlazorHeroContext _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IStringLocalizer<ChatService> _localizer;

        public ChatService(
            BlazorHeroContext context,
            IMapper mapper,
            IUserService userService,
            IStringLocalizer<ChatService> localizer)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
            _localizer = localizer;
        }

        public async Task<Result<IEnumerable<ChatHistoryResponse>>> GetChatHistoryAsync(string userId, string contactId)
        {
            var response = await _userService.GetAsync(userId);
            if (response.Succeeded)
            {
                var user = response.Data;
                var query = await _context.ChatHistories
                    .Where(h => (h.FromUserId == userId && h.ToUserId == contactId) || (h.FromUserId == contactId && h.ToUserId == userId))
                    .OrderBy(a => a.CreatedDate)
                    .Include(a => a.FromUser)
                    .Include(a => a.ToUser)
                    .Select(x => new ChatHistoryResponse
                    {
                        FromUserId = x.FromUserId,
                        FromUserFullName = $"{x.FromUser.FirstName} {x.FromUser.LastName}",
                        Message = x.Message,
                        CreatedDate = x.CreatedDate,
                        Id = x.Id,
                        ToUserId = x.ToUserId,
                        ToUserFullName = $"{x.ToUser.FirstName} {x.ToUser.LastName}",
                        ToUserImageURL = x.ToUser.ProfilePictureDataUrl,
                        FromUserImageURL = x.FromUser.ProfilePictureDataUrl
                    }).ToListAsync();
                return await Result<IEnumerable<ChatHistoryResponse>>.SuccessAsync(query);
            }
            else
            {
                throw new ApiException(_localizer["User Not Found!"]);
            }
        }

        public async Task<Result<IEnumerable<ChatUserResponse>>> GetChatUsersAsync(string userId)
        {
            var allUsers = await _context.Users.Where(user => user.Id != userId).ToListAsync();
            var chatUsers = _mapper.Map<IEnumerable<ChatUserResponse>>(allUsers).ToList();
            return await Result<IEnumerable<ChatUserResponse>>.SuccessAsync(chatUsers);
        }

        public async Task<Result<IEnumerable<ChatUserResponse>>> GetOldMessages(string userId)
        {
            //var allUsers = await _context.Users.Where(user => user.Id != userId).ToListAsync();
            var allUsers = await _context.Users.Where(x => x.Id != userId).Where(user => user.ChatHistoryFromUsers.Where(x => x.FromUserId == userId || x.ToUserId == userId).Count() > 0 || user.ChatHistoryToUsers.Where(x => x.FromUserId == userId || x.ToUserId == userId).Count() > 0).ToListAsync();
            var chatUsers = _mapper.Map<IEnumerable<ChatUserResponse>>(allUsers).ToList();
            var History = await _context.ChatHistories.Where(y => y.FromUserId == userId || y.ToUserId == userId).ToListAsync();
            chatUsers.ForEach((x) =>
            {
                var LastMessage = History.Where(y => y.FromUserId == x.Id || y.ToUserId == x.Id).OrderByDescending(y => y.Id).FirstOrDefault();
                x.LastMessage = LastMessage.Message;
                if (LastMessage.FromUserId != userId)
                {
                    x.Readed = LastMessage.isReaded;
                }
            }
                );
            return await Result<IEnumerable<ChatUserResponse>>.SuccessAsync(chatUsers);

        }

        public async Task<IResult> MarkAllAsRead(string userId)
        {
            var Messages = await _context.ChatHistories.Where(x => x.ToUserId == userId).ToListAsync();
            foreach (var item in Messages)
            {
                item.isReaded = true;
            }
            await _context.SaveChangesAsync();
            return await Result.SuccessAsync();
        }

        public async Task<IResult> MarkAsRead(string userId, string Coontactuser)
        {
            var Messages = await _context.ChatHistories.Where(x => x.FromUserId == Coontactuser && x.ToUserId == userId).ToListAsync();
            foreach (var item in Messages)
            {
                item.isReaded = true;
            }
            await _context.SaveChangesAsync();
            return await Result.SuccessAsync();
        }

        public async Task<IResult> SaveMessageAsync(ChatHistory message)
        {

            message.ToUser = await _context.Users.Where(user => user.Id == message.ToUserId).FirstOrDefaultAsync();


            await _context.ChatHistories.AddAsync(message);
            await _context.SaveChangesAsync();
            return await Result.SuccessAsync();
        }
    }
}