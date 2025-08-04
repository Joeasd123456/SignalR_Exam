namespace API_Kokak.Model
{
    public class ChatMessageModel
    {
        public string FromUser { get; set; } = string.Empty;
        public string ToUser { get; set; } = string.Empty;
        public string? Message { get; set; }
        public string? ImagePath { get; set; }
        public DateTime SentAt { get; set; } = DateTime.UtcNow;
    }
}
