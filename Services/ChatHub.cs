namespace API_Kokak.Services
{
    using API_Kokak.Interface;
    using API_Kokak.Model;
    using Microsoft.AspNetCore.SignalR;

    public class ChatHub : Hub
    {

        private readonly IChatMessageRepository _chatRepo;

        public ChatHub(IChatMessageRepository chatRepo)
        {
            _chatRepo = chatRepo;
        }

        // Called when a user connects
        public override async Task OnConnectedAsync()
        {
            var username = Context.GetHttpContext()?.Request.Query["user"].ToString();
            Console.WriteLine($"User connected: {username}, ConnId: {Context.ConnectionId}");

            if (!string.IsNullOrEmpty(username))
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, username);
                Console.WriteLine($"Added {Context.ConnectionId} to group {username}");
            }

            await base.OnConnectedAsync();
        }



        // Send private message to another user
        public async Task SendPrivateMessage(string toUser, string fromUser, string message)
        {

            var chatMessage = new ChatMessageModel
            {
                FromUser = fromUser,
                ToUser = toUser,
                Message = message,
                SentAt = DateTime.UtcNow
            };

            await _chatRepo.SaveMessageAsync(chatMessage);

            Console.WriteLine($"Sending message from {fromUser} to {toUser}: {message}");

            // Send to receiver
            await Clients.Group(toUser).SendAsync("ReceivePrivateMessage", fromUser, message);

            // Also send to sender (so they see their own message)
            await Clients.Group(fromUser).SendAsync("ReceivePrivateMessage", fromUser, message);
        }

        // send image
        public async Task SendPrivateImage(string toUser, string fromUser, string imagePath)
        {

            // Send to receiver
            await Clients.Group(toUser).SendAsync("ReceivePrivateImage", fromUser, imagePath);

            // Also send to sender (so they see their own image)
            await Clients.Group(fromUser).SendAsync("ReceivePrivateImage", fromUser, imagePath);
        }

    }
}