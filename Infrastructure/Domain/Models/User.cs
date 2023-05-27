using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Capstonep2.Infrastructure.Domain.Models
{
    public class User
    {
        public Guid? ID { get; set; }
        public Guid? ClientID { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public string? Address { get; set; }
        public Enums.Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public Guid? RoleID { get; set; }

        [ForeignKey("RoleID")]
        public Role? Role { get; set; }
        [ForeignKey("ClientID")]
        public Client? Client { get; set; }
    }


}