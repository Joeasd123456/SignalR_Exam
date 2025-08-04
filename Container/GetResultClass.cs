namespace API_Kokak.Container
{
    public class APIResponse
    {
        public int ResponseCode { get; set; }
        public string Result { get; set; }
        public List<string> Message { get; set; }
    }
}

