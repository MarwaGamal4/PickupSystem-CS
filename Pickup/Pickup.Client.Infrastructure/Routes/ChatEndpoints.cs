
namespace Pickup.Client.Infrastructure.Routes
{
    public static class ChatEndpoint
    {
        public static string GetAvailableUsers = "api/chats/users";
        public static string SaveMessage = "api/chats";
        public static string OldChat = "api/chats/oldchat";
        public static string MarkAllAsRead = "api/chats/MarkAll";

        public static string GetChatHistory(string userId)
        {
            return $"api/chats/{userId}";
        }
        public static string MarkAsRead(string userId)
        {
            return $"api/chats/Mark/{userId}";
        }
    }
}