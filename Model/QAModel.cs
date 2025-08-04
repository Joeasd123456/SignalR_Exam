namespace API_Kokak.Model
{
    public class QAModel
    {
        public int? qaId { get; set; } = 0;
        public string question { get; set; } = string.Empty;
        public string answer { get; set; } = string.Empty;
        public int? cateId { get; set; } = 0;
      
    }
    public class GetQAModel
    {
        public int? qaId { get; set; } = 0;
        public string question { get; set; } = string.Empty;
        public string answer { get; set; } = string.Empty;
      
    }
}
