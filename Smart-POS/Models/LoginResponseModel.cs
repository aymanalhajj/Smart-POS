namespace Smart_POS.Models
{
    public class LoginResponseModel
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public string? Token { get; set; }
        public int? SessionId { get; set; }
        public int? LangId { get; set; }
        public int? UserId { get; set; }
        public int? CompanyId { get; set; }
    }
}
