using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalvinSAD.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FirstName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MiddleName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Abbreviation = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Type = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Key = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    StartTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    PatientID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Visit = table.Column<int>(type: "int", nullable: false),
                    FDescription = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Appointments_Clients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Clients",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ClientID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MiddleName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RoleID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AppointmentID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Payments_Appointments_AppointmentID",
                        column: x => x.AppointmentID,
                        principalTable: "Appointments",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AppointmentID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Providers_Appointments_AppointmentID",
                        column: x => x.AppointmentID,
                        principalTable: "Appointments",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AppointmentID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Appointments_AppointmentID",
                        column: x => x.AppointmentID,
                        principalTable: "Appointments",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    RoleID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ApptPayment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AppointmentId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    FindingId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApptPayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApptPayment_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ApptPayment_Payments_FindingId",
                        column: x => x.FindingId,
                        principalTable: "Payments",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ApptProviders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ProviderId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    AppointmetId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    AppointmentID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApptProviders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApptProviders_Appointments_AppointmentID",
                        column: x => x.AppointmentID,
                        principalTable: "Appointments",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ApptProviders_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ApptSevices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AppointmentId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ServiceId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApptSevices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApptSevices_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ApptSevices_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ID", "Address", "BirthDate", "FirstName", "Gender", "LastName", "MiddleName" },
                values: new object[,]
                {
                    { new Guid("2b792220-f333-49ec-abe2-3a6fc4edb0c2"), "Luakan,Dinalupihan, Bataan", new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luisa Katrina", 0, "Reyes", "Pangilinan" },
                    { new Guid("5a7e7bc3-8816-41df-b44d-eeb60ae99b5b"), "Luakan,Dinalupihan, Bataan", new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clarissa Joy", 0, "Flores", "Gozon" },
                    { new Guid("8664a4bd-0ec6-4aaa-83e6-7d2bd0315b5a"), "Bacong,Hermosa, Bataan", new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Raniel", 1, "David", "Mallari" }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "ID", "AppointmentID", "FName" },
                values: new object[,]
                {
                    { new Guid("332d1fb4-35f1-48d8-ac19-f66472fce607"), null, "Debit Card" },
                    { new Guid("629d1da5-bf42-4dd5-9eda-614ba1260f03"), null, "Mobile Payment" },
                    { new Guid("672a4093-269e-47aa-879c-738cf2bf5e55"), null, "Checks" },
                    { new Guid("ab7f6ecf-7e82-4281-b90d-69f4ef72b66a"), null, "Electronic Bank Transfer" },
                    { new Guid("efd1381a-4c3d-4260-aaf2-04a0a26591bc"), null, "Cash" }
                });

            migrationBuilder.InsertData(
                table: "Providers",
                columns: new[] { "Id", "AppointmentID", "Name" },
                values: new object[,]
                {
                    { new Guid("3042ec44-a9b3-4bee-8a3d-14fd9f5167f7"), null, "VANGIE" },
                    { new Guid("70b4d9b7-e5bf-4da4-a355-a0af2da1d587"), null, "SID" },
                    { new Guid("7f28dca4-e0f4-4798-a823-f44cdcd2a3b0"), null, "CJ" },
                    { new Guid("912f8c3e-3ca7-4703-a858-2b9bc7612096"), null, "GING" },
                    { new Guid("9f87d3db-3842-4a4d-8552-b568c7f44620"), null, "5" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "Abbreviation", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("2afa881f-e519-4e67-a841-e4a2630e8a2a"), "Pt", "One who receives medical treatment", "patient" },
                    { new Guid("54f00f70-72b8-4d34-a953-83321ff6b101"), "Adm", "One who manages the system", "admin" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "AppointmentID", "Name" },
                values: new object[,]
                {
                    { new Guid("0bd555b4-5d90-4033-abd7-2b19dfce9f41"), null, "Manicure" },
                    { new Guid("10cbac3c-2dbf-45c9-8832-e6d2dd0b2168"), null, "Foot spa" },
                    { new Guid("32d18f17-4f8f-4534-9394-703261e2390b"), null, "Body Massage" },
                    { new Guid("e0d9efd5-c988-4692-aafd-c0096b0093ff"), null, "Pedicure" }
                });

            migrationBuilder.InsertData(
                table: "UserLogins",
                columns: new[] { "ID", "Key", "Type", "UserID", "Value" },
                values: new object[,]
                {
                    { new Guid("0ddfe7e3-ab0d-4aa5-9252-44d0848001bd"), "LoginRetries", "General", new Guid("d7dbd16f-1c71-4415-a147-22a2b428bf95"), "0" },
                    { new Guid("1c820215-20b5-4d1c-97c8-20c353e469d7"), "LoginRetries", "General", new Guid("0352c124-f290-4f99-b1a5-e235cafcd836"), "0" },
                    { new Guid("29bbd546-d92a-4d58-af04-bffaef438574"), "Password", "General", new Guid("d7dbd16f-1c71-4415-a147-22a2b428bf95"), "$2a$11$yW26u6x85VO9L5AqCkYae.Qq0PYb9/ZBT2aBqFqthxUOQrCcooVPG" },
                    { new Guid("2e55d6ca-8739-4775-b415-5c420aa99730"), "LoginRetries", "General", new Guid("1bd5f519-b891-4491-9a7c-a86cd0c2a15e"), "0" },
                    { new Guid("3966e31b-6075-437d-ae0e-94632179904e"), "Password", "General", new Guid("1bd5f519-b891-4491-9a7c-a86cd0c2a15e"), "$2a$11$BOfs09XszwdzkUPemGZP9Ohkm0vxYQ.7e6PVii0FYJq7cRRtD.1m." },
                    { new Guid("54506ffe-9d58-46cf-a6ce-8cebc329b7b9"), "Password", "General", new Guid("7e5e4f74-9902-43da-9974-4b2a08814398"), "$2a$11$ufztDVjQ/N6BPxAW1Bt/COPsOf3D5GLhkCcg14RHr8zVn13TWVKrG" },
                    { new Guid("6e862a66-7f02-468a-b4c5-e5813b2694cc"), "LoginRetries", "General", new Guid("00acfb7f-6c90-459a-b53f-bf73ddac85b4"), "0" },
                    { new Guid("94c65fc2-0f4b-461d-a9b2-b4b835f917ba"), "Password", "General", new Guid("0352c124-f290-4f99-b1a5-e235cafcd836"), "$2a$11$fJTbKjfgB.3wkBvoByWGI.d2P1VRZw2GL8LIQEhSRZc2bLh/uu9wi" },
                    { new Guid("9bde566c-acf2-4128-ab0b-16f24b9b6f1b"), "IsActive", "General", new Guid("00acfb7f-6c90-459a-b53f-bf73ddac85b4"), "true" },
                    { new Guid("cd0fbd6f-88ea-4ba0-bfd2-e89885b00754"), "LoginRetries", "General", new Guid("7e5e4f74-9902-43da-9974-4b2a08814398"), "0" },
                    { new Guid("d1af8473-8c02-4319-b8b6-dc6339fef60d"), "IsActive", "General", new Guid("7e5e4f74-9902-43da-9974-4b2a08814398"), "true" },
                    { new Guid("d913bf27-d4ce-4209-87c8-66ae013a68ab"), "IsActive", "General", new Guid("0352c124-f290-4f99-b1a5-e235cafcd836"), "true" },
                    { new Guid("ddc9a805-0019-4927-a176-1ea4cfa84b2f"), "IsActive", "General", new Guid("1bd5f519-b891-4491-9a7c-a86cd0c2a15e"), "true" },
                    { new Guid("fa3146ca-8a27-414b-a8a9-9a0f5072de0a"), "Password", "General", new Guid("00acfb7f-6c90-459a-b53f-bf73ddac85b4"), "$2a$11$FgRfpfXVpIGI68n9OWC5Muc/sBQoNGM5lKKeOdY49RHxgz4VJRQWK" },
                    { new Guid("ffcd7c53-07e9-47ea-99d6-bde03a60b42d"), "IsActive", "General", new Guid("d7dbd16f-1c71-4415-a147-22a2b428bf95"), "true" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Address", "BirthDate", "ClientID", "Email", "FirstName", "Gender", "LastName", "MiddleName", "RoleID" },
                values: new object[,]
                {
                    { new Guid("00acfb7f-6c90-459a-b53f-bf73ddac85b4"), "Dinalupihan, Orani , Bataan", new DateTime(2002, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Admin@yahoo.com", "Roberto", 0, "Escobar", "Adan", new Guid("54f00f70-72b8-4d34-a953-83321ff6b101") },
                    { new Guid("0352c124-f290-4f99-b1a5-e235cafcd836"), "Dinalupihan, Orani, Bataan", new DateTime(2001, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2b792220-f333-49ec-abe2-3a6fc4edb0c2"), "luisa@yahoo.com", "Luisa Katrina", 0, "Pangilinan", "Reyes", new Guid("2afa881f-e519-4e67-a841-e4a2630e8a2a") },
                    { new Guid("1bd5f519-b891-4491-9a7c-a86cd0c2a15e"), "Dinalupihan, Orani , Bataan", new DateTime(2002, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@yahoo.com", "Calvin", 0, "Admin", "NicDao", new Guid("54f00f70-72b8-4d34-a953-83321ff6b101") },
                    { new Guid("7e5e4f74-9902-43da-9974-4b2a08814398"), "Dinalupihan, Orani, Bataan", new DateTime(2001, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8664a4bd-0ec6-4aaa-83e6-7d2bd0315b5a"), "client@yahoo.com", "Calvin", 1, "CLient", "NicDao", new Guid("2afa881f-e519-4e67-a841-e4a2630e8a2a") },
                    { new Guid("d7dbd16f-1c71-4415-a147-22a2b428bf95"), "Dinalupihan, Orani, Bataan", new DateTime(2001, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5a7e7bc3-8816-41df-b44d-eeb60ae99b5b"), "joy@yahoo.com", "Clarissa Joy", 1, "Gozon", "Flores", new Guid("2afa881f-e519-4e67-a841-e4a2630e8a2a") }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleID", "UserID" },
                values: new object[,]
                {
                    { new Guid("a695b208-ebd7-4b8b-8685-173f3d4ca9af"), new Guid("2afa881f-e519-4e67-a841-e4a2630e8a2a"), new Guid("0352c124-f290-4f99-b1a5-e235cafcd836") },
                    { new Guid("b8bb0926-0bca-45ae-be02-d9ee62def8d0"), new Guid("2afa881f-e519-4e67-a841-e4a2630e8a2a"), new Guid("d7dbd16f-1c71-4415-a147-22a2b428bf95") },
                    { new Guid("cd06f1eb-6dbb-4148-a322-1579ff36e2ad"), new Guid("54f00f70-72b8-4d34-a953-83321ff6b101"), new Guid("00acfb7f-6c90-459a-b53f-bf73ddac85b4") },
                    { new Guid("d0f044f2-4bad-47d6-a085-ff099e556ef6"), new Guid("2afa881f-e519-4e67-a841-e4a2630e8a2a"), new Guid("7e5e4f74-9902-43da-9974-4b2a08814398") },
                    { new Guid("dfb463af-ecb6-45e2-9c0e-c0946a05cd3e"), new Guid("54f00f70-72b8-4d34-a953-83321ff6b101"), new Guid("1bd5f519-b891-4491-9a7c-a86cd0c2a15e") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientID",
                table: "Appointments",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_ApptPayment_AppointmentId",
                table: "ApptPayment",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ApptPayment_FindingId",
                table: "ApptPayment",
                column: "FindingId");

            migrationBuilder.CreateIndex(
                name: "IX_ApptProviders_AppointmentID",
                table: "ApptProviders",
                column: "AppointmentID");

            migrationBuilder.CreateIndex(
                name: "IX_ApptProviders_ProviderId",
                table: "ApptProviders",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_ApptSevices_AppointmentId",
                table: "ApptSevices",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ApptSevices_ServiceId",
                table: "ApptSevices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_AppointmentID",
                table: "Payments",
                column: "AppointmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Providers_AppointmentID",
                table: "Providers",
                column: "AppointmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Services_AppointmentID",
                table: "Services",
                column: "AppointmentID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleID",
                table: "UserRoles",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserID",
                table: "UserRoles",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ClientID",
                table: "Users",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApptPayment");

            migrationBuilder.DropTable(
                name: "ApptProviders");

            migrationBuilder.DropTable(
                name: "ApptSevices");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
