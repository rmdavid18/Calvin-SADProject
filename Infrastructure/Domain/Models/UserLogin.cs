namespace Capstonep2.Infrastructure.Domain.Models
{
    public class UserLogin
    {
        public Guid? ID { get; set; }
        public Guid? UserID { get; set; }
        public string? Type { get; set; } //Google, Facebook, General
        public string? Key { get; set; }
        public string? Value { get; set; }
    }
}
