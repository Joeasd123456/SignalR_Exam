using API_Kokak.Model;

namespace API_Kokak.Interface
{
    public interface IChatMessageRepository
    {
        Task SaveMessageAsync(ChatMessageModel message);
        Task<List<ChatMessageModel>> GetMessagesByReceiverAsync(string fromUser, string toUser);
    }
}
