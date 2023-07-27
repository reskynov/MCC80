namespace API.DTOs.Accounts
{
    public class OtpResponseDto
    {
        public Guid Guid { get; set; }
        public string Email { get; set; }
        public int Otp { get; set; }
    }
}
