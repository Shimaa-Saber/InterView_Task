namespace InterView_Task.GeneralResponse
{
    public class LoginResponse
    {
        public bool Success { get; set; }
        public string Token { get; set; }
        public DateTime Expiry { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
