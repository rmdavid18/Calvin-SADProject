namespace Capstonep2.Infrastructure.Domain.Models
{
    public class UserRole
    {
        public Guid? Id { get; set; }
        public Guid? UserID { get; set; }
        public User? User { get; set; }
        public Guid? RoleID { get; set; }
        public Role? Role { get; set; }
    }
}
