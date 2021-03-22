using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FindR1_2.Data.Migrations
{
    public partial class initialUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ConsumedTime",
                table: "PersistedGrants",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PersistedGrants",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SessionId",
                table: "PersistedGrants",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "DeviceCodes",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SessionId",
                table: "DeviceCodes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AttendsTo",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePicture",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "Advertisements",
                columns: table => new
                {
                    AdvertisementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisements", x => x.AdvertisementId);
                    table.ForeignKey(
                        name: "FK_Advertisements_AspNetUsers_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Housings",
                columns: table => new
                {
                    HousingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(type: "int", nullable: false),
                    NoOfRooms = table.Column<int>(type: "int", nullable: false),
                    AdvertisementId = table.Column<int>(type: "int", nullable: true),
                    IsTaken = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Housings", x => x.HousingId);
                    table.ForeignKey(
                        name: "FK_Housings_Advertisements_AdvertisementId",
                        column: x => x.AdvertisementId,
                        principalTable: "Advertisements",
                        principalColumn: "AdvertisementId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompleteAddresses",
                columns: table => new
                {
                    CompleteAddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Floor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    HousingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompleteAddresses", x => x.CompleteAddressId);
                    table.ForeignKey(
                        name: "FK_CompleteAddresses_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompleteAddresses_Housings_HousingId",
                        column: x => x.HousingId,
                        principalTable: "Housings",
                        principalColumn: "HousingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "City", "Country", "Zone" },
                values: new object[,]
                {
                    { 1, "Alba-Iulia", "Romania", 0 },
                    { 65, "Suceava", "Romania", 0 },
                    { 64, "Slobozia", "Romania", 0 },
                    { 63, "Slobozia", "Romania", 1 },
                    { 62, "Slatina", "Romania", 0 },
                    { 61, "Slatina", "Romania", 1 },
                    { 60, "Sibiu", "Romania", 0 },
                    { 59, "Sibiu", "Romania", 1 },
                    { 58, "Sfantu Gheorghe", "Romania", 0 },
                    { 66, "Suceava", "Romania", 1 },
                    { 56, "Satu Mare", "Romania", 0 },
                    { 54, "Resita", "Romania", 0 },
                    { 53, "Resita", "Romania", 1 },
                    { 52, "Ramnicu Valcea", "Romania", 0 },
                    { 51, "Ramnicu Valcea", "Romania", 1 },
                    { 50, "Ploiesti", "Romania", 0 },
                    { 49, "Ploiesti", "Romania", 1 },
                    { 48, "Pitesti", "Romania", 0 },
                    { 47, "Pitesti", "Romania", 1 },
                    { 55, "Satu Mare", "Romania", 1 },
                    { 46, "Piatra Neamt", "Romania", 0 },
                    { 67, "Targoviste", "Romania", 0 },
                    { 69, "Targu Jiu", "Romania", 0 },
                    { 87, "Bucuresti", "Romania", 1 },
                    { 86, "Bucuresti, Sector6", "Romania", 0 },
                    { 85, "Bucuresti, Sector5", "Romania", 0 },
                    { 84, "Bucuresti, Sector4", "Romania", 0 },
                    { 83, "Bucuresti, Sector3", "Romania", 0 },
                    { 82, "Bucuresti, Sector2", "Romania", 0 },
                    { 81, "Bucuresti, Sector1", "Romania", 0 },
                    { 80, "Zalau", "Romania", 0 },
                    { 68, "Targoviste", "Romania", 1 },
                    { 79, "Zalau", "Romania", 1 },
                    { 77, "Vaslui", "Romania", 0 },
                    { 76, "Tulcea", "Romania", 1 },
                    { 75, "Tulcea", "Romania", 0 },
                    { 74, "Timisoara", "Romania", 1 },
                    { 73, "Timisoara", "Romania", 0 },
                    { 72, "Targu Mures", "Romania", 1 },
                    { 71, "Targu Mures", "Romania", 0 },
                    { 70, "Targu Jiu", "Romania", 1 },
                    { 78, "Vaslui", "Romania", 1 }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "City", "Country", "Zone" },
                values: new object[,]
                {
                    { 45, "Piatra Neamt", "Romania", 1 },
                    { 57, "Sfantu Gheorghe", "Romania", 1 },
                    { 43, "Oradea", "Romania", 1 },
                    { 20, "Buzau", "Romania", 1 },
                    { 19, "Buzau", "Romania", 0 },
                    { 18, "Braila", "Romania", 1 },
                    { 17, "Braila", "Romania", 0 },
                    { 16, "Brasov", "Romania", 1 },
                    { 15, "Brasov", "Romania", 0 },
                    { 14, "Botosani", "Romania", 1 },
                    { 13, "Botosani", "Romania", 0 },
                    { 12, "Bistrita", "Romania", 1 },
                    { 11, "Bistrita", "Romania", 0 },
                    { 44, "Oradea", "Romania", 0 },
                    { 9, "Baia Mare", "Romania", 0 },
                    { 8, "Bacau", "Romania", 1 },
                    { 7, "Bacau", "Romania", 0 },
                    { 6, "Arad", "Romania", 1 },
                    { 5, "Arad", "Romania", 0 },
                    { 4, "Alexandria", "Romania", 1 },
                    { 3, "Alexandria", "Romania", 0 },
                    { 2, "Alba-Iulia", "Romania", 1 },
                    { 21, "Calarasi", "Romania", 0 },
                    { 22, "Calarasi", "Romania", 1 },
                    { 10, "Baia Mare", "Romania", 1 },
                    { 24, "Cluj-Napoca", "Romania", 1 },
                    { 23, "Cluj-Napoca", "Romania", 0 },
                    { 42, "Miercurea-Ciuc", "Romania", 0 },
                    { 41, "Miercurea-Ciuc", "Romania", 1 },
                    { 40, "Iasi", "Romania", 0 },
                    { 39, "Iasi", "Romania", 1 },
                    { 37, "Giurgiu", "Romania", 1 },
                    { 36, "Galati", "Romania", 0 },
                    { 35, "Galati", "Romania", 1 },
                    { 34, "Focsani", "Romania", 0 },
                    { 38, "Giurgiu", "Romania", 0 },
                    { 32, "Drobeta-Turnu-Severin", "Romania", 1 },
                    { 31, "Drobeta-Turnu-Severin", "Romania", 0 },
                    { 30, "Deva", "Romania", 1 },
                    { 29, "Deva", "Romania", 0 },
                    { 28, "Craiova", "Romania", 1 },
                    { 27, "Craiova", "Romania", 0 }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "City", "Country", "Zone" },
                values: new object[,]
                {
                    { 26, "Constanta", "Romania", 1 },
                    { 33, "Focsani", "Romania", 1 },
                    { 25, "Constanta", "Romania", 0 }
                });

            migrationBuilder.InsertData(
                table: "Housings",
                columns: new[] { "HousingId", "AdvertisementId", "IsTaken", "NoOfRooms", "Price" },
                values: new object[,]
                {
                    { 17, null, false, 3, 2500 },
                    { 18, null, false, 1, 1300 },
                    { 19, null, false, 3, 1500 },
                    { 20, null, false, 2, 1300 },
                    { 21, null, false, 2, 800 },
                    { 26, null, false, 2, 1000 },
                    { 25, null, false, 3, 1800 },
                    { 27, null, false, 1, 500 },
                    { 16, null, false, 2, 1200 },
                    { 28, null, false, 2, 1800 },
                    { 22, null, false, 1, 1300 },
                    { 15, null, false, 3, 1250 },
                    { 4, null, false, 4, 2000 },
                    { 13, null, false, 2, 700 },
                    { 12, null, false, 2, 1400 },
                    { 11, null, false, 2, 900 },
                    { 10, null, false, 2, 1000 },
                    { 9, null, false, 3, 1700 },
                    { 8, null, false, 2, 900 },
                    { 6, null, false, 2, 1100 },
                    { 5, null, false, 1, 600 },
                    { 3, null, false, 2, 1200 },
                    { 2, null, false, 2, 1000 },
                    { 1, null, false, 1, 600 },
                    { 29, null, false, 3, 1700 },
                    { 14, null, false, 2, 900 },
                    { 30, null, false, 4, 3000 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AddressId", "Age", "AttendsTo", "BirthDate", "ConcurrencyStamp", "Details", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a24d8022-adae-459b-b788-7242fac46783", 0, 1, 20, 7, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2dfb6633-4fa1-4c70-b591-35c14eb97c9e", "Hi, I am Bot1!", "Testbot1@yahoo.com", true, "Test1", 0, "Bot1", false, null, "TESTBOT1@YAHOO.COM", "TESTBOT1@YAHOO.COM", "AQAAAAEAACcQAAAAEOTzVhwRddkitd3UyFDJH+fIaU7BfrtgbM18HXbfN+tjUVOhSACNBMouuzG0Fi0GxQ==", null, false, null, "f4507a46-5202-442e-9328-fd08699e654f", false, "Testbot1@yahoo.com" },
                    { "4e2e4d95-0c75-4e94-8bb9-c5d689e137d7", 0, 6, 19, 7, new DateTime(2001, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "a1e2bde0-4c46-4b40-a3ea-d9a509897fa2", "Hi, I am Bot2!", "Testbot2@yahoo.com", true, "Test2", 0, "Bot2", false, null, "TESTBOT2@YAHOO.COM", "TESTBOT2@YAHOO.COM", "AQAAAAEAACcQAAAAEPLemjmkS3yejmtRnMxHkB27hndAeZcuToWOgLJDacV6PYb9+V6M4mPd1nEpwWNNrw==", null, false, null, "0a75f115-25de-49c1-8234-e8ecb26ace0d", false, "Testbot2@yahoo.com" },
                    { "3b164904-fc73-459a-bb48-43e85dc163c1", 0, 10, 22, 23, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "c3774bf0-c907-4a5d-9adb-5feaeccad478", "Hi, I am Bot3!", "Testbot3@yahoo.com", true, "Test3", 1, "Bot3", false, null, "TESTBOT3@YAHOO.COM", "TESTBOT3@YAHOO.COM", "AQAAAAEAACcQAAAAEPOi602s5nt9g4kw3VT9W0OlCybl1dxY5V3M5tpoo7h03MZIb9ASLYpXybq0MYVfPg==", null, false, null, "ef715ee4-fba2-43aa-ac01-360cb8ad51fa", false, "Testbot3@yahoo.com" },
                    { "dc54bba7-75b4-4065-b96d-cbaa565e88bc", 0, 35, 21, 24, new DateTime(2000, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "79aab502-8e7e-4d17-a587-e238c9e15ac4", "Hi, I am Bot4!", "Testbot4@yahoo.com", true, "Test4", 0, "Bot4", false, null, "TESTBOT4@YAHOO.COM", "TESTBOT4@YAHOO.COM", "AQAAAAEAACcQAAAAEADJRuGlqh/o5zpMKqP7kQfsvfrVkoC6VMEj1sx0l4wdSOfqVAk5nCVFCQjPlQ8jlw==", null, false, null, "b94c428e-01b1-48ff-af9c-674ff2cfc0f1", false, "Testbot4@yahoo.com" },
                    { "49fb19d5-8e79-4b07-8def-97a18831165f", 0, 39, 23, 23, new DateTime(1998, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "16f684ff-f4b8-4443-bde5-a800579580d7", "Hi, I am Bot5!", "Testbot5@yahoo.com", true, "Test5", 1, "Bot5", false, null, "TESTBOT5@YAHOO.COM", "TESTBOT5@YAHOO.COM", "AQAAAAEAACcQAAAAEM/qr+KTwGdJZWh+NwyB3//VC1fXdHEWfqUxg/DeKM9hEFXxawbSZhHJWJHl8DDXfg==", null, false, null, "3b9653d0-e2dc-4384-820c-6e25a0fba376", false, "Testbot5@yahoo.com" },
                    { "405d96a0-e830-4d45-9845-5d6fdb81b8c9", 0, 48, 18, 0, new DateTime(2002, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "a702bb04-9867-405a-a6de-6e5e2c315e59", "Hi, I am Bot6!", "Testbot6@yahoo.com", true, "Test6", 0, "Bot6", false, null, "TESTBOT6@YAHOO.COM", "TESTBOT6@YAHOO.COM", "AQAAAAEAACcQAAAAENWld65QLpepsRggtYm7iq45cPmGaPSp2pIYePmoj46L57nS3ibI5mmKDjkKLonlJg==", null, false, null, "42fceaaf-7b2c-45a1-b7b2-d5e0aa1fe7df", false, "Testbot6@yahoo.com" },
                    { "f36ff8e7-7441-42cb-bdec-f3608eaa4af5", 0, 52, 22, 0, new DateTime(1999, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "90cab393-4dca-499d-abf4-8174434e7ff8", "Hi, I am Bot7!", "Testbot7@yahoo.com", true, "Test7", 1, "Bot7", false, null, "TESTBOT7@YAHOO.COM", "TESTBOT7@YAHOO.COM", "AQAAAAEAACcQAAAAEBJoeM0WOIZCtt5+BSKFKjcTixs8Mn+WsCQu/raiisCLH2r++fYMIyg9felXYuCMig==", null, false, null, "b1666508-e7a8-46e4-bbe4-78674b1346e8", false, "Testbot7@yahoo.com" },
                    { "72391fa7-4466-478b-957d-e5892654c8b0", 0, 68, 20, 0, new DateTime(2000, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "d6bc0a7d-8888-4dd8-9f2b-b1144f53476e", "Hi, I am Bot8!", "Testbot8@yahoo.com", true, "Test8", 1, "Bot8", false, null, "TESTBOT8@YAHOO.COM", "TESTBOT8@YAHOO.COM", "AQAAAAEAACcQAAAAEKplGmxQfLpwFVcUcqxDBB3PwBYD0eC+DAcEZYTTlnvdM8zhXj1P0QgLjLHZgi9AdA==", null, false, null, "4ed032c2-1e2b-4db1-b0ee-f4aba5654f68", false, "Testbot8@yahoo.com" },
                    { "6950bc44-dc3a-46cf-900b-d1379a71d266", 0, 81, 22, 0, new DateTime(1999, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "1a3e7161-8447-442d-9bba-a501d8c0f140", "Hi, I am Bot9!", "Testbot9@yahoo.com", true, "Test9", 0, "Bot9", false, null, "TESTBOT9@YAHOO.COM", "TESTBOT9@YAHOO.COM", "AQAAAAEAACcQAAAAEKdJqTT6u8snVyAfH+akMQFX5c/oicIzCGTIWAHn0fpq5PYfvMl8wZXg+eHjlFHU7g==", null, false, null, "f3ddb4d5-9410-4aa0-9451-f50b0e5dbc17", false, "Testbot9@yahoo.com" },
                    { "261874ec-9711-4cb0-873b-ba9125615189", 0, 84, 20, 0, new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "76fa8a40-60f5-402a-bd49-894784048159", "Hi, I am Bot10!", "Testbot10@yahoo.com", true, "Test10", 1, "Bot10", false, null, "TESTBOT10@YAHOO.COM", "TESTBOT10@YAHOO.COM", "AQAAAAEAACcQAAAAEPYi4FNi07wlgw/X1H21KqVcail8YksCtOhAIImncRpPGtNoF0zY76krHEKs83R3VQ==", null, false, null, "1ab0e074-d129-4abd-8fa0-d64af1aa5f81", false, "Testbot10@yahoo.com" }
                });

            migrationBuilder.InsertData(
                table: "CompleteAddresses",
                columns: new[] { "CompleteAddressId", "AddressId", "Floor", "HousingId", "Latitude", "Longitude", "Street" },
                values: new object[,]
                {
                    { 17, 24, "3", 17, "46.794320", "23.524650", "Strada Magnoliei 70" },
                    { 18, 81, "5", 18, "46.794320", "23.524650", "Bulevardul Dinica Golescu 43" },
                    { 19, 82, "6", 19, "44.438978", "26.173939", "Strada Bodesti 2" },
                    { 20, 82, "9", 20, "44.452571", "26.102739", "Soseaua Stefan cel Mare 11" },
                    { 21, 83, "3", 21, "44.414781", "26.183618", "Strada Gura Ialomitei 3" },
                    { 28, 86, "3", 28, "44.435211", "26.036348", "Aleea Cetatuia 10" },
                    { 25, 85, "Parter", 25, "44.394717", "26.043258", "Strada Botosani 26" },
                    { 26, 85, "8", 26, "44.404615", "26.059843", "Strada Topolinita 59" },
                    { 27, 86, "3", 27, "44.420257", "26.004572", "Aleea Pupaza cu Mot 22" },
                    { 16, 73, "5", 16, "45.755140", "21.223142", "Strada Paris 2" },
                    { 22, 83, "2", 22, "44.416427", "26.127926", "Strada Zizin 18" },
                    { 15, 73, "1", 15, "45.775033", "21.228275", "Strada Ion Miron 34" },
                    { 10, 25, "2", 10, "44.201169", "28.647306", "Strada Ioan Borcea 35" },
                    { 13, 56, "3", 13, "47.785716", "22.860054", "Bulevardul Muncii 36" },
                    { 12, 25, "Parter", 12, "44.197265", "28.627114", "Strada Dorului 53" },
                    { 11, 25, "Parter", 11, "44.187265", "28.627114", "Strada Dorului 57" },
                    { 29, 87, "Parter", 29, "43.377385", "26.166757", "Strada Veseliei 29" },
                    { 9, 24, "3", 9, "46.794320", "23.524650", "Strada Magnoliei 70" },
                    { 8, 23, "1", 8, "46.763605", "23.596262", "Strada Aviator Badescu 34" },
                    { 6, 23, "4", 6, "46.756804", "23.559443", "Strada Ion Mester 3" },
                    { 5, 15, "Parter", 5, "45.655480", "25.594241", "Strada Sitei 84" },
                    { 4, 15, "Parter,1", 4, "45.661322", "25.599990", "Strada Vulcan 49" },
                    { 3, 15, "1", 3, "45.640371", "25.624299", "Strada Zorilor 13" },
                    { 2, 2, "Parter", 2, "46.175409", "21.310149", "Strada Octaviang Goga 34" },
                    { 1, 1, "2", 1, "46.066828", "23.554441", "Strada Gladiolelor 8" },
                    { 14, 60, "4", 14, "45.785642", "24.134520", "Strada Hategului 5" },
                    { 30, 87, "2", 30, "44.552820", "26.070561", "Strada Floare de Cais 13" }
                });

            migrationBuilder.InsertData(
                table: "Advertisements",
                columns: new[] { "AdvertisementId", "CheckInDate", "ProfileId" },
                values: new object[] { 1, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "a24d8022-adae-459b-b788-7242fac46783" });

            migrationBuilder.InsertData(
                table: "Advertisements",
                columns: new[] { "AdvertisementId", "CheckInDate", "ProfileId" },
                values: new object[] { 3, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "dc54bba7-75b4-4065-b96d-cbaa565e88bc" });

            migrationBuilder.InsertData(
                table: "Advertisements",
                columns: new[] { "AdvertisementId", "CheckInDate", "ProfileId" },
                values: new object[] { 2, new DateTime(2021, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "49fb19d5-8e79-4b07-8def-97a18831165f" });

            migrationBuilder.InsertData(
                table: "Housings",
                columns: new[] { "HousingId", "AdvertisementId", "IsTaken", "NoOfRooms", "Price" },
                values: new object[] { 7, 1, true, 3, 1500 });

            migrationBuilder.InsertData(
                table: "Housings",
                columns: new[] { "HousingId", "AdvertisementId", "IsTaken", "NoOfRooms", "Price" },
                values: new object[] { 24, 3, true, 2, 1450 });

            migrationBuilder.InsertData(
                table: "Housings",
                columns: new[] { "HousingId", "AdvertisementId", "IsTaken", "NoOfRooms", "Price" },
                values: new object[] { 23, 2, true, 2, 1600 });

            migrationBuilder.InsertData(
                table: "CompleteAddresses",
                columns: new[] { "CompleteAddressId", "AddressId", "Floor", "HousingId", "Latitude", "Longitude", "Street" },
                values: new object[] { 7, 23, "Parter", 7, "46.766510", "23.609383", "Strada Vasile Lupu 24" });

            migrationBuilder.InsertData(
                table: "CompleteAddresses",
                columns: new[] { "CompleteAddressId", "AddressId", "Floor", "HousingId", "Latitude", "Longitude", "Street" },
                values: new object[] { 24, 84, "1", 24, "44.413708", "26.114010", "Calea Vacaresti 184" });

            migrationBuilder.InsertData(
                table: "CompleteAddresses",
                columns: new[] { "CompleteAddressId", "AddressId", "Floor", "HousingId", "Latitude", "Longitude", "Street" },
                values: new object[] { 23, 84, "Parter", 23, "44.411703", "26.113875", "Calea Vacaresti 232" });

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_SessionId_Type",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "SessionId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_ProfileId",
                table: "Advertisements",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_CompleteAddresses_AddressId",
                table: "CompleteAddresses",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CompleteAddresses_HousingId",
                table: "CompleteAddresses",
                column: "HousingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Housings_AdvertisementId",
                table: "Housings",
                column: "AdvertisementId",
                unique: true,
                filter: "[AdvertisementId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressId",
                table: "AspNetUsers",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CompleteAddresses");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Housings");

            migrationBuilder.DropTable(
                name: "Advertisements");

            migrationBuilder.DropIndex(
                name: "IX_PersistedGrants_SubjectId_SessionId_Type",
                table: "PersistedGrants");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "261874ec-9711-4cb0-873b-ba9125615189");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b164904-fc73-459a-bb48-43e85dc163c1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "405d96a0-e830-4d45-9845-5d6fdb81b8c9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4e2e4d95-0c75-4e94-8bb9-c5d689e137d7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6950bc44-dc3a-46cf-900b-d1379a71d266");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "72391fa7-4466-478b-957d-e5892654c8b0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f36ff8e7-7441-42cb-bdec-f3608eaa4af5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "49fb19d5-8e79-4b07-8def-97a18831165f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a24d8022-adae-459b-b788-7242fac46783");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dc54bba7-75b4-4065-b96d-cbaa565e88bc");

            migrationBuilder.DropColumn(
                name: "ConsumedTime",
                table: "PersistedGrants");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "PersistedGrants");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "PersistedGrants");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "DeviceCodes");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "DeviceCodes");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AttendsTo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Details",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "AspNetUsers");
        }
    }
}
