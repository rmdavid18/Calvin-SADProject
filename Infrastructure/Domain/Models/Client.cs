namespace Capstonep2.Infrastructure.Domain.Models
{
    public class Client
    {
        public Guid? ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public string? Address { get; set; }

        public DateTime BirthDate { get; set; }
        public Enums.Gender Gender { get; set; }

    }


}
