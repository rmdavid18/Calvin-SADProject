using Capstonep2.Infrastructure.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Capstonep2.Infrastructure.Domain
{

    public class DefaultDBContext : DbContext
    {
        public DefaultDBContext(DbContextOptions<DefaultDBContext> options): base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
      
        public DbSet<Payment> Payments { get; set; }
       
        public DbSet<User> Users { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<ApptSevice> ApptSevices { get; set; }
        public DbSet<ApptProvider> ApptProviders { get; set; }
        public DbSet<ApptPayment> ApptPayment { get; set; }
      


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            List<Client> clients = new List<Client>();
          
            List<Payment> payments = new List<Payment>();
            List<User> users = new List<User>();
            List<Role> roles = new List<Role>();
            List<Appointment> appointments = new List<Appointment>();
       
            List<UserLogin> userLogins = new List<UserLogin>();
            List<UserRole> userRoles = new List<UserRole>();
            List<Service> services = new List<Service>();
            List<Provider> providers = new List<Provider>();
            List<ApptSevice> apptSymptoms = new List<ApptSevice>();
            List<ApptProvider> apptPurposes = new List<ApptProvider>();
         
            List<ApptPayment> apptPayments = new List<ApptPayment>();


           

            payments.Add(new Payment()
            {
                ID = Guid.Parse("efd1381a-4c3d-4260-aaf2-04a0a26591bc"),
                FName = "Cash"
              
            });
            payments.Add(new Payment()
            {
                ID = Guid.Parse("672a4093-269e-47aa-879c-738cf2bf5e55"),
                FName = "Checks"
                
            });
            payments.Add(new Payment()
            {
                ID = Guid.Parse("332d1fb4-35f1-48d8-ac19-f66472fce607"),
                FName = "Debit Card"
                
            });
            payments.Add(new Payment()
            {
                ID = Guid.Parse("629d1da5-bf42-4dd5-9eda-614ba1260f03"),
                FName = "Mobile Payment"
                
            });
            payments.Add(new Payment()
            {
                ID = Guid.Parse("ab7f6ecf-7e82-4281-b90d-69f4ef72b66a"),
                FName = "Electronic Bank Transfer"
                

            });




            //p
            services.Add(new Service()
            {
                Id = Guid.Parse("32d18f17-4f8f-4534-9394-703261e2390b"),
                Name = "Body Massage"
            });
            services.Add(new Service()
            {
                Id = Guid.Parse("10cbac3c-2dbf-45c9-8832-e6d2dd0b2168"),
                Name = "Foot spa"
            });
            services.Add(new Service()
            {
                Id = Guid.Parse("0bd555b4-5d90-4033-abd7-2b19dfce9f41"),
                Name = "Manicure"
            });
            services.Add(new Service()
            {
                Id = Guid.Parse("e0d9efd5-c988-4692-aafd-c0096b0093ff"),
                Name = "Pedicure"
            });

           
           
           

            //Purpose
            providers.Add(new Provider()
            {
                Id = Guid.Parse("7f28dca4-e0f4-4798-a823-f44cdcd2a3b0"),
                Name = "CJ"
            });
            providers.Add(new Provider()
            {
                Id = Guid.Parse("70b4d9b7-e5bf-4da4-a355-a0af2da1d587"),
                Name = "SID"
            });
            providers.Add(new Provider()
            {
                Id = Guid.Parse("912f8c3e-3ca7-4703-a858-2b9bc7612096"),
                Name = "GING"
            });
            providers.Add(new Provider()
            {
                Id = Guid.Parse("3042ec44-a9b3-4bee-8a3d-14fd9f5167f7"),
                Name = "VANGIE"
            });
            providers.Add(new Provider()
            {
                Id = Guid.Parse("9f87d3db-3842-4a4d-8552-b568c7f44620"),
                Name = "5"
            });
            //



            //patientt3
            clients.Add(new Client()
            {
                ID = Guid.Parse("2b792220-f333-49ec-abe2-3a6fc4edb0c2"),
                FirstName = "Luisa Katrina",
                MiddleName = "Pangilinan",
                LastName = "Reyes",
                Address = "Luakan,Dinalupihan, Bataan",
                BirthDate = DateTime.Parse("23/03/2023"),

                Gender = Models.Enums.Gender.Female
            });

            users.Add(new User()
            {
                ID = Guid.Parse("0352c124-f290-4f99-b1a5-e235cafcd836"),
                ClientID = Guid.Parse("2b792220-f333-49ec-abe2-3a6fc4edb0c2"),
                Email = "luisa@yahoo.com",
                FirstName = "Luisa Katrina",
                LastName = "Pangilinan",
                MiddleName = "Reyes",
                BirthDate = DateTime.Parse("23/01/2001"),
                Gender = Models.Enums.Gender.Female,
                RoleID = Guid.Parse("2afa881f-e519-4e67-a841-e4a2630e8a2a"),
                Address = "Dinalupihan, Orani, Bataan"
            });
            userLogins.AddRange(new List<UserLogin>()
            {
                new UserLogin()
                {
                    ID = Guid.NewGuid(),
                    UserID =Guid.Parse("0352c124-f290-4f99-b1a5-e235cafcd836"),
                    Type = "General",
                    Key = "Password",
                    Value = BCrypt.Net.BCrypt.EnhancedHashPassword("patient")
                },
                new UserLogin()
                {
                    ID = Guid.NewGuid(),
                    UserID =Guid.Parse("0352c124-f290-4f99-b1a5-e235cafcd836"),
                    Type = "General",
                    Key = "IsActive",
                    Value = "true"
                },
                new UserLogin()
                {
                    ID = Guid.NewGuid(),
                    UserID =Guid.Parse("0352c124-f290-4f99-b1a5-e235cafcd836"),
                    Type = "General",
                    Key = "LoginRetries",
                    Value = "0"
                }
            });
            userRoles.Add(new UserRole()
            {
                Id = Guid.NewGuid(),
                UserID = Guid.Parse("0352c124-f290-4f99-b1a5-e235cafcd836"),
                RoleID = Guid.Parse("2afa881f-e519-4e67-a841-e4a2630e8a2a"),
            });
            //pa3
            //patient2
            clients.Add(new Client()
            {
                ID = Guid.Parse("5a7e7bc3-8816-41df-b44d-eeb60ae99b5b"),
                FirstName = "Clarissa Joy",
                MiddleName = "Gozon",
                LastName = "Flores",
                Address = "Luakan,Dinalupihan, Bataan",
                BirthDate = DateTime.Parse("23/03/2023"),

                Gender = Models.Enums.Gender.Female
            });
            //patient2
            //user2
            users.Add(new User()
            {
                ID = Guid.Parse("d7dbd16f-1c71-4415-a147-22a2b428bf95"),
                ClientID = Guid.Parse("5a7e7bc3-8816-41df-b44d-eeb60ae99b5b"),
                Email = "joy@yahoo.com",
                FirstName = "Clarissa Joy",
                LastName = "Gozon",
                MiddleName = "Flores",
                BirthDate = DateTime.Parse("23/01/2001"),
                Gender = Models.Enums.Gender.Male,
                RoleID = Guid.Parse("2afa881f-e519-4e67-a841-e4a2630e8a2a"),
                Address = "Dinalupihan, Orani, Bataan"
            });
            userLogins.AddRange(new List<UserLogin>()
            {
                new UserLogin()
                {
                    ID = Guid.NewGuid(),
                    UserID =Guid.Parse("d7dbd16f-1c71-4415-a147-22a2b428bf95"),
                    Type = "General",
                    Key = "Password",
                    Value = BCrypt.Net.BCrypt.EnhancedHashPassword("capstone")
                },
                new UserLogin()
                {
                    ID = Guid.NewGuid(),
                    UserID =Guid.Parse("d7dbd16f-1c71-4415-a147-22a2b428bf95"),
                    Type = "General",
                    Key = "IsActive",
                    Value = "true"
                },
                new UserLogin()
                {
                    ID = Guid.NewGuid(),
                    UserID =Guid.Parse("d7dbd16f-1c71-4415-a147-22a2b428bf95"),
                    Type = "General",
                    Key = "LoginRetries",
                    Value = "0"
                }
            });
            userRoles.Add(new UserRole()
            {
                Id = Guid.NewGuid(),
                UserID = Guid.Parse("d7dbd16f-1c71-4415-a147-22a2b428bf95"),
                RoleID = Guid.Parse("2afa881f-e519-4e67-a841-e4a2630e8a2a"),
            });
            // user2

            //appts2
       
          

          
           

            clients.Add(new Client()
            {
                ID = Guid.Parse("8664a4bd-0ec6-4aaa-83e6-7d2bd0315b5a"),
                FirstName = "Raniel",
                MiddleName = "Mallari",
                LastName = "David",
                Address = "Bacong,Hermosa, Bataan",
                BirthDate = DateTime.Parse("23/03/2023"),

                Gender = Models.Enums.Gender.Male
            });


            users.Add(new User()
            {
                ID = Guid.Parse("7e5e4f74-9902-43da-9974-4b2a08814398"),
                ClientID = Guid.Parse("8664a4bd-0ec6-4aaa-83e6-7d2bd0315b5a"),
                Email = "client@yahoo.com",
                FirstName = "Calvin",
                LastName = "CLient",
                MiddleName = "NicDao",
                BirthDate = DateTime.Parse("23/01/2001"),
                Gender = Models.Enums.Gender.Male,
                RoleID = Guid.Parse("2afa881f-e519-4e67-a841-e4a2630e8a2a"),
                Address = "Dinalupihan, Orani, Bataan"
            });
            //adminacc
            users.Add(new User()
            {
                ID = Guid.Parse("1bd5f519-b891-4491-9a7c-a86cd0c2a15e"),
                Email = "admin@yahoo.com",
                FirstName = "Calvin",
                LastName = "Admin",
                MiddleName = "NicDao",
                BirthDate = DateTime.Parse("21/02/2002"),

                Gender = Models.Enums.Gender.Female,
                RoleID = Guid.Parse("54f00f70-72b8-4d34-a953-83321ff6b101"),
                Address = "Dinalupihan, Orani , Bataan"

            });
            userLogins.AddRange(new List<UserLogin>()
            {
                new UserLogin()
                {
                    ID = Guid.NewGuid(),
                    UserID =Guid.Parse("1bd5f519-b891-4491-9a7c-a86cd0c2a15e"),
                    Type = "General",
                    Key = "Password",
                    Value = BCrypt.Net.BCrypt.EnhancedHashPassword("admin")
                },
                new UserLogin()
                {
                    ID = Guid.NewGuid(),
                    UserID =Guid.Parse("1bd5f519-b891-4491-9a7c-a86cd0c2a15e"),
                    Type = "General",
                    Key = "IsActive",
                    Value = "true"
                },
                new UserLogin()
                {
                    ID = Guid.NewGuid(),
                    UserID =Guid.Parse("1bd5f519-b891-4491-9a7c-a86cd0c2a15e"),
                    Type = "General",
                    Key = "LoginRetries",
                    Value = "0"
                }
            });
            userRoles.Add(new UserRole()
            {
                Id = Guid.NewGuid(),
                UserID = Guid.Parse("1bd5f519-b891-4491-9a7c-a86cd0c2a15e"),
                RoleID = Guid.Parse("54f00f70-72b8-4d34-a953-83321ff6b101"),
            });


            //

            users.Add(new User()
            {
                ID = Guid.Parse("00acfb7f-6c90-459a-b53f-bf73ddac85b4"),
                Email = "Admin@yahoo.com",
                FirstName = "Roberto",
                LastName = "Escobar",
                MiddleName = "Adan",
                BirthDate = DateTime.Parse("21/02/2002"),

                Gender = Models.Enums.Gender.Female,
                RoleID = Guid.Parse("54f00f70-72b8-4d34-a953-83321ff6b101"),
                Address = "Dinalupihan, Orani , Bataan"

            });
            userLogins.AddRange(new List<UserLogin>()
            {
                new UserLogin()
                {
                    ID = Guid.NewGuid(),
                    UserID =Guid.Parse("00acfb7f-6c90-459a-b53f-bf73ddac85b4"),
                    Type = "General",
                    Key = "Password",
                    Value = BCrypt.Net.BCrypt.EnhancedHashPassword("admin")
                },
                new UserLogin()
                {
                    ID = Guid.NewGuid(),
                    UserID =Guid.Parse("00acfb7f-6c90-459a-b53f-bf73ddac85b4"),
                    Type = "General",
                    Key = "IsActive",
                    Value = "true"
                },
                new UserLogin()
                {
                    ID = Guid.NewGuid(),
                    UserID =Guid.Parse("00acfb7f-6c90-459a-b53f-bf73ddac85b4"),
                    Type = "General",
                    Key = "LoginRetries",
                    Value = "0"
                }
            });
            userRoles.Add(new UserRole()
            {
                Id = Guid.NewGuid(),
                UserID = Guid.Parse("00acfb7f-6c90-459a-b53f-bf73ddac85b4"),
                RoleID = Guid.Parse("54f00f70-72b8-4d34-a953-83321ff6b101"),
            });
            //role
            roles.Add(new Role()
            {
                ID = Guid.Parse("2afa881f-e519-4e67-a841-e4a2630e8a2a"),
                Name = "patient",
                Abbreviation = "Pt",
                Description = "One who receives medical treatment"
            });

            roles.Add(new Role()
            {
                ID = Guid.Parse("54f00f70-72b8-4d34-a953-83321ff6b101"),
                Name = "admin",
                Abbreviation = "Adm",
                Description = "One who manages the system"
            });
            //role

            userLogins.AddRange(new List<UserLogin>()
            {
                new UserLogin()
                {
                    ID = Guid.NewGuid(),
                    UserID =Guid.Parse("7e5e4f74-9902-43da-9974-4b2a08814398"),
                    Type = "General",
                    Key = "Password",
                    Value = BCrypt.Net.BCrypt.EnhancedHashPassword("client")
                },
                new UserLogin()
                {
                    ID = Guid.NewGuid(),
                    UserID =Guid.Parse("7e5e4f74-9902-43da-9974-4b2a08814398"),
                    Type = "General",
                    Key = "IsActive",
                    Value = "true"
                },
                new UserLogin()
                {
                    ID = Guid.NewGuid(),
                    UserID =Guid.Parse("7e5e4f74-9902-43da-9974-4b2a08814398"),
                    Type = "General",
                    Key = "LoginRetries",
                    Value = "0"
                }
            });
            userRoles.Add(new UserRole()
            {
                Id = Guid.NewGuid(),
                UserID = Guid.Parse("7e5e4f74-9902-43da-9974-4b2a08814398"),
                RoleID = Guid.Parse("2afa881f-e519-4e67-a841-e4a2630e8a2a"),
            });




           
            modelBuilder.Entity<Payment>().HasData(payments);
            modelBuilder.Entity<Client>().HasData(clients);
            
            modelBuilder.Entity<Appointment>().HasData(appointments);
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<UserLogin>().HasData(userLogins);
            modelBuilder.Entity<Role>().HasData(roles);
            modelBuilder.Entity<UserRole>().HasData(userRoles);
            modelBuilder.Entity<Service>().HasData(services);
            modelBuilder.Entity<Provider>().HasData(providers);
            modelBuilder.Entity<ApptSevice>().HasData(apptSymptoms);
            modelBuilder.Entity<ApptProvider>().HasData(apptPurposes);
            modelBuilder.Entity<ApptPayment>().HasData(apptPayments);
            
            

        }

    }
}
