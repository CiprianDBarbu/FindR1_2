using FindR1_2.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindR1_2.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<CompleteAddress> CompleteAddresses { get; set; }
        public DbSet<Housing> Housings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Housing>()
                .HasOne(a => a.FullAddress)
                .WithOne(b => b.Housing)
                .HasForeignKey<CompleteAddress>(h => h.HousingId);

            builder.Entity<Advertisement>()
                .HasOne(a => a.Housing)
                .WithOne(h => h.Advertisement);


            builder.Entity<CompleteAddress>()
                .HasOne(a => a.Address)
                .WithMany(b => b.CompleteAddresses);

            builder.Entity<ApplicationUser>()
                .HasOne(a => a.Adress)
                .WithMany(b => b.ApplicationUsers);

            builder.Entity<Advertisement>()
                .HasOne(a => a.Profile)
                .WithMany(b => b.Advertisements);

            #region Address seed
            builder.Entity<Address>()
                .HasData(
                    new Address { Address_Id = 1, Country = "Romania", City = "Alba-Iulia", Zone = ZoneType.Urban },
                    new Address { Address_Id = 2, Country = "Romania", City = "Alba-Iulia", Zone = ZoneType.Rural },
                    new Address { Address_Id = 3, Country = "Romania", City = "Alexandria", Zone = ZoneType.Urban },
                    new Address { Address_Id = 4, Country = "Romania", City = "Alexandria", Zone = ZoneType.Rural },
                    new Address { Address_Id = 5, Country = "Romania", City = "Arad", Zone = ZoneType.Urban },
                    new Address { Address_Id = 6, Country = "Romania", City = "Arad", Zone = ZoneType.Rural },
                    new Address { Address_Id = 7, Country = "Romania", City = "Bacau", Zone = ZoneType.Urban },
                    new Address { Address_Id = 8, Country = "Romania", City = "Bacau", Zone = ZoneType.Rural },
                    new Address { Address_Id = 9, Country = "Romania", City = "Baia Mare", Zone = ZoneType.Urban },
                    new Address { Address_Id = 10, Country = "Romania", City = "Baia Mare", Zone = ZoneType.Rural },
                    new Address { Address_Id = 11, Country = "Romania", City = "Bistrita", Zone = ZoneType.Urban },
                    new Address { Address_Id = 12, Country = "Romania", City = "Bistrita", Zone = ZoneType.Rural },
                    new Address { Address_Id = 13, Country = "Romania", City = "Botosani", Zone = ZoneType.Urban },
                    new Address { Address_Id = 14, Country = "Romania", City = "Botosani", Zone = ZoneType.Rural },
                    new Address { Address_Id = 15, Country = "Romania", City = "Brasov", Zone = ZoneType.Urban },
                    new Address { Address_Id = 16, Country = "Romania", City = "Brasov", Zone = ZoneType.Rural },
                    new Address { Address_Id = 17, Country = "Romania", City = "Braila", Zone = ZoneType.Urban },
                    new Address { Address_Id = 18, Country = "Romania", City = "Braila", Zone = ZoneType.Rural },
                    new Address { Address_Id = 19, Country = "Romania", City = "Buzau", Zone = ZoneType.Urban },
                    new Address { Address_Id = 20, Country = "Romania", City = "Buzau", Zone = ZoneType.Rural },
                    new Address { Address_Id = 21, Country = "Romania", City = "Calarasi", Zone = ZoneType.Urban },
                    new Address { Address_Id = 22, Country = "Romania", City = "Calarasi", Zone = ZoneType.Rural },
                    new Address { Address_Id = 23, Country = "Romania", City = "Cluj-Napoca", Zone = ZoneType.Urban },
                    new Address { Address_Id = 24, Country = "Romania", City = "Cluj-Napoca", Zone = ZoneType.Rural },
                    new Address { Address_Id = 25, Country = "Romania", City = "Constanta", Zone = ZoneType.Urban },
                    new Address { Address_Id = 26, Country = "Romania", City = "Constanta", Zone = ZoneType.Rural },
                    new Address { Address_Id = 27, Country = "Romania", City = "Craiova", Zone = ZoneType.Urban },
                    new Address { Address_Id = 28, Country = "Romania", City = "Craiova", Zone = ZoneType.Rural },
                    new Address { Address_Id = 29, Country = "Romania", City = "Deva", Zone = ZoneType.Urban },
                    new Address { Address_Id = 30, Country = "Romania", City = "Deva", Zone = ZoneType.Rural },
                    new Address { Address_Id = 31, Country = "Romania", City = "Drobeta-Turnu-Severin", Zone = ZoneType.Urban },
                    new Address { Address_Id = 32, Country = "Romania", City = "Drobeta-Turnu-Severin", Zone = ZoneType.Rural },
                    new Address { Address_Id = 33, Country = "Romania", City = "Focsani", Zone = ZoneType.Rural },
                    new Address { Address_Id = 34, Country = "Romania", City = "Focsani", Zone = ZoneType.Urban },
                    new Address { Address_Id = 35, Country = "Romania", City = "Galati", Zone = ZoneType.Rural },
                    new Address { Address_Id = 36, Country = "Romania", City = "Galati", Zone = ZoneType.Urban },
                    new Address { Address_Id = 37, Country = "Romania", City = "Giurgiu", Zone = ZoneType.Rural },
                    new Address { Address_Id = 38, Country = "Romania", City = "Giurgiu", Zone = ZoneType.Urban },
                    new Address { Address_Id = 39, Country = "Romania", City = "Iasi", Zone = ZoneType.Rural },
                    new Address { Address_Id = 40, Country = "Romania", City = "Iasi", Zone = ZoneType.Urban },
                    new Address { Address_Id = 41, Country = "Romania", City = "Miercurea-Ciuc", Zone = ZoneType.Rural },
                    new Address { Address_Id = 42, Country = "Romania", City = "Miercurea-Ciuc", Zone = ZoneType.Urban },
                    new Address { Address_Id = 43, Country = "Romania", City = "Oradea", Zone = ZoneType.Rural },
                    new Address { Address_Id = 44, Country = "Romania", City = "Oradea", Zone = ZoneType.Urban },
                    new Address { Address_Id = 45, Country = "Romania", City = "Piatra Neamt", Zone = ZoneType.Rural },
                    new Address { Address_Id = 46, Country = "Romania", City = "Piatra Neamt", Zone = ZoneType.Urban },
                    new Address { Address_Id = 47, Country = "Romania", City = "Pitesti", Zone = ZoneType.Rural },
                    new Address { Address_Id = 48, Country = "Romania", City = "Pitesti", Zone = ZoneType.Urban },
                    new Address { Address_Id = 49, Country = "Romania", City = "Ploiesti", Zone = ZoneType.Rural },
                    new Address { Address_Id = 50, Country = "Romania", City = "Ploiesti", Zone = ZoneType.Urban },
                    new Address { Address_Id = 51, Country = "Romania", City = "Ramnicu Valcea", Zone = ZoneType.Rural },
                    new Address { Address_Id = 52, Country = "Romania", City = "Ramnicu Valcea", Zone = ZoneType.Urban },
                    new Address { Address_Id = 53, Country = "Romania", City = "Resita", Zone = ZoneType.Rural },
                    new Address { Address_Id = 54, Country = "Romania", City = "Resita", Zone = ZoneType.Urban },
                    new Address { Address_Id = 55, Country = "Romania", City = "Satu Mare", Zone = ZoneType.Rural },
                    new Address { Address_Id = 56, Country = "Romania", City = "Satu Mare", Zone = ZoneType.Urban },
                    new Address { Address_Id = 57, Country = "Romania", City = "Sfantu Gheorghe", Zone = ZoneType.Rural },
                    new Address { Address_Id = 58, Country = "Romania", City = "Sfantu Gheorghe", Zone = ZoneType.Urban },
                    new Address { Address_Id = 59, Country = "Romania", City = "Sibiu", Zone = ZoneType.Rural },
                    new Address { Address_Id = 60, Country = "Romania", City = "Sibiu", Zone = ZoneType.Urban },
                    new Address { Address_Id = 61, Country = "Romania", City = "Slatina", Zone = ZoneType.Rural },
                    new Address { Address_Id = 62, Country = "Romania", City = "Slatina", Zone = ZoneType.Urban },
                    new Address { Address_Id = 63, Country = "Romania", City = "Slobozia", Zone = ZoneType.Rural },
                    new Address { Address_Id = 64, Country = "Romania", City = "Slobozia", Zone = ZoneType.Urban },
                    new Address { Address_Id = 65, Country = "Romania", City = "Suceava", Zone = ZoneType.Urban },
                    new Address { Address_Id = 66, Country = "Romania", City = "Suceava", Zone = ZoneType.Rural },
                    new Address { Address_Id = 67, Country = "Romania", City = "Targoviste", Zone = ZoneType.Urban },
                    new Address { Address_Id = 68, Country = "Romania", City = "Targoviste", Zone = ZoneType.Rural },
                    new Address { Address_Id = 69, Country = "Romania", City = "Targu Jiu", Zone = ZoneType.Urban },
                    new Address { Address_Id = 70, Country = "Romania", City = "Targu Jiu", Zone = ZoneType.Rural },
                    new Address { Address_Id = 71, Country = "Romania", City = "Targu Mures", Zone = ZoneType.Urban },
                    new Address { Address_Id = 72, Country = "Romania", City = "Targu Mures", Zone = ZoneType.Rural },
                    new Address { Address_Id = 73, Country = "Romania", City = "Timisoara", Zone = ZoneType.Urban },
                    new Address { Address_Id = 74, Country = "Romania", City = "Timisoara", Zone = ZoneType.Rural },
                    new Address { Address_Id = 75, Country = "Romania", City = "Tulcea", Zone = ZoneType.Urban },
                    new Address { Address_Id = 76, Country = "Romania", City = "Tulcea", Zone = ZoneType.Rural },
                    new Address { Address_Id = 77, Country = "Romania", City = "Vaslui", Zone = ZoneType.Urban },
                    new Address { Address_Id = 78, Country = "Romania", City = "Vaslui", Zone = ZoneType.Rural },
                    new Address { Address_Id = 79, Country = "Romania", City = "Zalau", Zone = ZoneType.Rural },
                    new Address { Address_Id = 80, Country = "Romania", City = "Zalau", Zone = ZoneType.Urban },
                    new Address { Address_Id = 81, Country = "Romania", City = "Bucuresti, Sector1", Zone = ZoneType.Urban },
                    new Address { Address_Id = 82, Country = "Romania", City = "Bucuresti, Sector2", Zone = ZoneType.Urban },
                    new Address { Address_Id = 83, Country = "Romania", City = "Bucuresti, Sector3", Zone = ZoneType.Urban },
                    new Address { Address_Id = 84, Country = "Romania", City = "Bucuresti, Sector4", Zone = ZoneType.Urban },
                    new Address { Address_Id = 85, Country = "Romania", City = "Bucuresti, Sector5", Zone = ZoneType.Urban },
                    new Address { Address_Id = 86, Country = "Romania", City = "Bucuresti, Sector6", Zone = ZoneType.Urban },
                    new Address { Address_Id = 87, Country = "Romania", City = "Bucuresti", Zone = ZoneType.Rural }
                    );
            #endregion

            #region CompleteAddress seed
            builder.Entity<CompleteAddress>()
                .HasData(
                new CompleteAddress { CompleteAddress_Id = 1, AddressId = 1, HousingId = 1, Street = "Strada Gladiolelor 8", Floor = "2", Latitude = "46.066828", Longitude = "23.554441" },
                new CompleteAddress { CompleteAddress_Id = 2, AddressId = 2, HousingId = 2, Street = "Strada Octaviang Goga 34", Floor = "Parter", Latitude = "46.175409", Longitude = "21.310149" },
                new CompleteAddress { CompleteAddress_Id = 3, AddressId = 15, HousingId = 3, Street = "Strada Zorilor 13", Floor = "1", Latitude = "45.640371", Longitude = "25.624299" },
                new CompleteAddress { CompleteAddress_Id = 4, AddressId = 15, HousingId = 4, Street = "Strada Vulcan 49", Floor = "Parter,1", Latitude = "45.661322", Longitude = "25.599990" },
                new CompleteAddress { CompleteAddress_Id = 5, AddressId = 15, HousingId = 5, Street = "Strada Sitei 84", Floor = "Parter", Latitude = "45.655480", Longitude = "25.594241" },
                new CompleteAddress { CompleteAddress_Id = 6, AddressId = 23, HousingId = 6, Street = "Strada Ion Mester 3", Floor = "4", Latitude = "46.756804", Longitude = "23.559443" },
                new CompleteAddress { CompleteAddress_Id = 7, AddressId = 23, HousingId = 7, Street = "Strada Vasile Lupu 24", Floor = "Parter", Latitude = "46.766510", Longitude = "23.609383" },
                new CompleteAddress { CompleteAddress_Id = 8, AddressId = 23, HousingId = 8, Street = "Strada Aviator Badescu 34", Floor = "1", Latitude = "46.763605", Longitude = "23.596262" },
                new CompleteAddress { CompleteAddress_Id = 9, AddressId = 24, HousingId = 9, Street = "Strada Magnoliei 70", Floor = "3", Latitude = "46.794320", Longitude = "23.524650" },
                new CompleteAddress { CompleteAddress_Id = 10, AddressId = 25, HousingId = 10, Street = "Strada Ioan Borcea 35", Floor = "2", Latitude = "44.201169", Longitude = "28.647306" },
                new CompleteAddress { CompleteAddress_Id = 11, AddressId = 25, HousingId = 11, Street = "Strada Dorului 57", Floor = "Parter", Latitude = "44.187265", Longitude = "28.627114" },
                new CompleteAddress { CompleteAddress_Id = 12, AddressId = 25, HousingId = 12, Street = "Strada Dorului 53", Floor = "Parter", Latitude = "44.197265", Longitude = "28.627114" },
                new CompleteAddress { CompleteAddress_Id = 13, AddressId = 56, HousingId = 13, Street = "Bulevardul Muncii 36", Floor = "3", Latitude = "47.785716", Longitude = "22.860054" },
                new CompleteAddress { CompleteAddress_Id = 14, AddressId = 60, HousingId = 14, Street = "Strada Hategului 5", Floor = "4", Latitude = "45.785642", Longitude = "24.134520" },
                new CompleteAddress { CompleteAddress_Id = 15, AddressId = 73, HousingId = 15, Street = "Strada Ion Miron 34", Floor = "1", Latitude = "45.775033", Longitude = "21.228275" },
                new CompleteAddress { CompleteAddress_Id = 16, AddressId = 73, HousingId = 16, Street = "Strada Paris 2", Floor = "5", Latitude = "45.755140", Longitude = "21.223142" },
                new CompleteAddress { CompleteAddress_Id = 17, AddressId = 24, HousingId = 17, Street = "Strada Magnoliei 70", Floor = "3", Latitude = "46.794320", Longitude = "23.524650" },
                new CompleteAddress { CompleteAddress_Id = 18, AddressId = 81, HousingId = 18, Street = "Bulevardul Dinica Golescu 43", Floor = "5", Latitude = "46.794320", Longitude = "23.524650" },
                new CompleteAddress { CompleteAddress_Id = 19, AddressId = 82, HousingId = 19, Street = "Strada Bodesti 2", Floor = "6", Latitude = "44.438978", Longitude = "26.173939" },
                new CompleteAddress { CompleteAddress_Id = 20, AddressId = 82, HousingId = 20, Street = "Soseaua Stefan cel Mare 11", Floor = "9", Latitude = "44.452571", Longitude = "26.102739" },
                new CompleteAddress { CompleteAddress_Id = 21, AddressId = 83, HousingId = 21, Street = "Strada Gura Ialomitei 3", Floor = "3", Latitude = "44.414781", Longitude = "26.183618" },
                new CompleteAddress { CompleteAddress_Id = 22, AddressId = 83, HousingId = 22, Street = "Strada Zizin 18", Floor = "2", Latitude = "44.416427", Longitude = "26.127926" },
                new CompleteAddress { CompleteAddress_Id = 23, AddressId = 84, HousingId = 23, Street = "Calea Vacaresti 232", Floor = "Parter", Latitude = "44.411703", Longitude = "26.113875" },
                new CompleteAddress { CompleteAddress_Id = 24, AddressId = 84, HousingId = 24, Street = "Calea Vacaresti 184", Floor = "1", Latitude = "44.413708", Longitude = "26.114010" },
                new CompleteAddress { CompleteAddress_Id = 25, AddressId = 85, HousingId = 25, Street = "Strada Botosani 26", Floor = "Parter", Latitude = "44.394717", Longitude = "26.043258" },
                new CompleteAddress { CompleteAddress_Id = 26, AddressId = 85, HousingId = 26, Street = "Strada Topolinita 59", Floor = "8", Latitude = "44.404615", Longitude = "26.059843" },
                new CompleteAddress { CompleteAddress_Id = 27, AddressId = 86, HousingId = 27, Street = "Aleea Pupaza cu Mot 22", Floor = "3", Latitude = "44.420257", Longitude = "26.004572" },
                new CompleteAddress { CompleteAddress_Id = 28, AddressId = 86, HousingId = 28, Street = "Aleea Cetatuia 10", Floor = "3", Latitude = "44.435211", Longitude = "26.036348" },
                new CompleteAddress { CompleteAddress_Id = 29, AddressId = 87, HousingId = 29, Street = "Strada Veseliei 29", Floor = "Parter", Latitude = "43.377385", Longitude = "26.166757" },
                new CompleteAddress { CompleteAddress_Id = 30, AddressId = 87, HousingId = 30, Street = "Strada Floare de Cais 13", Floor = "2", Latitude = "44.552820", Longitude = "26.070561" }
                );
            #endregion

            #region Housing seed
            builder.Entity<Housing>()
               .HasData(
                new Housing { Housing_Id = 1, Price = 600, NoOfRooms = 1, IsTaken = false, AdvertisementId = null},
                new Housing { Housing_Id = 2, Price = 1000, NoOfRooms = 2, IsTaken = false, AdvertisementId = null },
                new Housing { Housing_Id = 3, Price = 1200, NoOfRooms = 2, IsTaken = false, AdvertisementId  = null },
                new Housing { Housing_Id = 4, Price = 2000, NoOfRooms = 4, IsTaken = false, AdvertisementId = null },
                new Housing { Housing_Id = 5, Price = 600, NoOfRooms = 1, IsTaken = false, AdvertisementId = null },
                new Housing { Housing_Id = 6, Price = 1100, NoOfRooms = 2, IsTaken = false, AdvertisementId = null },
                new Housing { Housing_Id = 7, Price = 1500, NoOfRooms = 3, IsTaken = true, AdvertisementId = 1 },
                new Housing { Housing_Id = 8, Price = 900, NoOfRooms = 2, IsTaken = false, AdvertisementId = null },
                new Housing { Housing_Id = 9, Price = 1700, NoOfRooms = 3, IsTaken = false, AdvertisementId = null },
                new Housing { Housing_Id = 10, Price = 1000, NoOfRooms = 2, IsTaken = false, AdvertisementId = null },
                new Housing { Housing_Id = 11, Price = 900, NoOfRooms = 2, IsTaken = false, AdvertisementId = null },
                new Housing { Housing_Id = 12, Price = 1400, NoOfRooms = 2, IsTaken = false, AdvertisementId = null },
                new Housing { Housing_Id = 13, Price = 700, NoOfRooms = 2, IsTaken = false, AdvertisementId = null },
                new Housing { Housing_Id = 14, Price = 900, NoOfRooms = 2, IsTaken = false, AdvertisementId = null },
                new Housing { Housing_Id = 15, Price = 1250, NoOfRooms = 3, IsTaken = false, AdvertisementId = null },
                new Housing { Housing_Id = 16, Price = 1200, NoOfRooms = 2, IsTaken = false, AdvertisementId = null },
                new Housing { Housing_Id = 17, Price = 2500, NoOfRooms = 3, IsTaken = false, AdvertisementId = null },
                new Housing { Housing_Id = 18, Price = 1300, NoOfRooms = 1, IsTaken = false, AdvertisementId = null },
                new Housing { Housing_Id = 19, Price = 1500, NoOfRooms = 3, IsTaken = false, AdvertisementId = null },
                new Housing { Housing_Id = 20, Price = 1300, NoOfRooms = 2, IsTaken = false, AdvertisementId = null },
                new Housing { Housing_Id = 21, Price = 800, NoOfRooms = 2, IsTaken = false, AdvertisementId = null },
                new Housing { Housing_Id = 22, Price = 1300, NoOfRooms = 1, IsTaken = false, AdvertisementId = null },
                new Housing { Housing_Id = 23, Price = 1600, NoOfRooms = 2, IsTaken = true, AdvertisementId = 2 },
                new Housing { Housing_Id = 24, Price = 1450, NoOfRooms = 2, IsTaken = true, AdvertisementId = 3 },
                new Housing { Housing_Id = 25, Price = 1800, NoOfRooms = 3, IsTaken = false, AdvertisementId = null },
                new Housing { Housing_Id = 26, Price = 1000, NoOfRooms = 2, IsTaken = false, AdvertisementId = null },
                new Housing { Housing_Id = 27, Price = 500, NoOfRooms = 1, IsTaken = false, AdvertisementId = null },
                new Housing { Housing_Id = 28, Price = 1800, NoOfRooms = 2, IsTaken = false, AdvertisementId = null },
                new Housing { Housing_Id = 29, Price = 1700, NoOfRooms = 3, IsTaken = false, AdvertisementId = null },
                new Housing { Housing_Id = 30, Price = 3000, NoOfRooms = 4, IsTaken = false, AdvertisementId = null }
               );
            #endregion

            #region ApplicationUser seed
            PasswordHasher<ApplicationUser> pH = new PasswordHasher<ApplicationUser>();

            ApplicationUser applicationUser1 = new ApplicationUser
            {
                UserName = "Testbot1@yahoo.com",
                Email = "Testbot1@yahoo.com",
                NormalizedEmail = "Testbot1@yahoo.com".ToUpper(),
                NormalizedUserName = "Testbot1@yahoo.com".ToUpper(),
                TwoFactorEnabled = false,
                EmailConfirmed = true,
                FirstName = "Test1",
                LastName = "Bot1",
                BirthDate = new DateTime(2000, 1, 1),
                Age = 20,
                Gender = GenderType.Male,
                Details = "Hi, I am Bot1!",
                AddressId = 1,
                AttendsTo = 7
            };
            applicationUser1.PasswordHash = pH.HashPassword(applicationUser1, "Testpass1!");


            ApplicationUser applicationUser2 = new ApplicationUser
            {
                UserName = "Testbot2@yahoo.com",
                Email = "Testbot2@yahoo.com",
                NormalizedEmail = "Testbot2@yahoo.com".ToUpper(),
                NormalizedUserName = "Testbot2@yahoo.com".ToUpper(),
                TwoFactorEnabled = false,
                EmailConfirmed = true,
                FirstName = "Test2",
                LastName = "Bot2",
                BirthDate = new DateTime(2001, 8, 23),
                Age = 19,
                Gender = GenderType.Male,
                Details = "Hi, I am Bot2!",
                AddressId = 6,
                AttendsTo = 7
            };
            applicationUser2.PasswordHash = pH.HashPassword(applicationUser2, "Testpass2!");


            ApplicationUser applicationUser3 = new ApplicationUser
            {
                UserName = "Testbot3@yahoo.com",
                Email = "Testbot3@yahoo.com",
                NormalizedEmail = "Testbot3@yahoo.com".ToUpper(),
                NormalizedUserName = "Testbot3@yahoo.com".ToUpper(),
                TwoFactorEnabled = false,
                EmailConfirmed = true,
                FirstName = "Test3",
                LastName = "Bot3",
                BirthDate = new DateTime(1999, 1, 1),
                Age = 22,
                Gender = GenderType.Female,
                Details = "Hi, I am Bot3!",
                AddressId = 10,
                AttendsTo = 23
            };
            applicationUser3.PasswordHash = pH.HashPassword(applicationUser3, "Testpass3!");


            ApplicationUser applicationUser4 = new ApplicationUser
            {
                UserName = "Testbot4@yahoo.com",
                Email = "Testbot4@yahoo.com",
                NormalizedEmail = "Testbot4@yahoo.com".ToUpper(),
                NormalizedUserName = "Testbot4@yahoo.com".ToUpper(),
                TwoFactorEnabled = false,
                EmailConfirmed = true,
                FirstName = "Test4",
                LastName = "Bot4",
                BirthDate = new DateTime(2000, 1, 24),
                Age = 21,
                Gender = GenderType.Male,
                Details = "Hi, I am Bot4!",
                AddressId = 35,
                AttendsTo = 24
            };
            applicationUser4.PasswordHash = pH.HashPassword(applicationUser4, "Testpass4!");


            ApplicationUser applicationUser5 = new ApplicationUser
            {
                UserName = "Testbot5@yahoo.com",
                Email = "Testbot5@yahoo.com",
                NormalizedEmail = "Testbot5@yahoo.com".ToUpper(),
                NormalizedUserName = "Testbot5@yahoo.com".ToUpper(),
                TwoFactorEnabled = false,
                EmailConfirmed = true,
                FirstName = "Test5",
                LastName = "Bot5",
                BirthDate = new DateTime(1998, 9, 13),
                Age = 23,
                Gender = GenderType.Female,
                Details = "Hi, I am Bot5!",
                AddressId = 39,
                AttendsTo = 23
            };
            applicationUser5.PasswordHash = pH.HashPassword(applicationUser5, "Testpass5!");


            ApplicationUser applicationUser6 = new ApplicationUser
            {
                UserName = "Testbot6@yahoo.com",
                Email = "Testbot6@yahoo.com",
                NormalizedEmail = "Testbot6@yahoo.com".ToUpper(),
                NormalizedUserName = "Testbot6@yahoo.com".ToUpper(),
                TwoFactorEnabled = false,
                EmailConfirmed = true,
                FirstName = "Test6",
                LastName = "Bot6",
                BirthDate = new DateTime(2002, 5, 1),
                Age = 18,
                Gender = GenderType.Male,
                Details = "Hi, I am Bot6!",
                AddressId = 48
            };
            applicationUser6.PasswordHash = pH.HashPassword(applicationUser6, "Testpass6!");


            ApplicationUser applicationUser7 = new ApplicationUser
            {
                UserName = "Testbot7@yahoo.com",
                Email = "Testbot7@yahoo.com",
                NormalizedEmail = "Testbot7@yahoo.com".ToUpper(),
                NormalizedUserName = "Testbot7@yahoo.com".ToUpper(),
                TwoFactorEnabled = false,
                EmailConfirmed = true,
                FirstName = "Test7",
                LastName = "Bot7",
                BirthDate = new DateTime(1999, 12, 23),
                Age = 22,
                Gender = GenderType.Female,
                Details = "Hi, I am Bot7!",
                AddressId = 52
            };
            applicationUser7.PasswordHash = pH.HashPassword(applicationUser7, "Testpass7!");


            ApplicationUser applicationUser8 = new ApplicationUser
            {
                UserName = "Testbot8@yahoo.com",
                Email = "Testbot8@yahoo.com",
                NormalizedEmail = "Testbot8@yahoo.com".ToUpper(),
                NormalizedUserName = "Testbot8@yahoo.com".ToUpper(),
                TwoFactorEnabled = false,
                EmailConfirmed = true,
                FirstName = "Test8",
                LastName = "Bot8",
                BirthDate = new DateTime(2000, 6, 3),
                Age = 20,
                Gender = GenderType.Female,
                Details = "Hi, I am Bot8!",
                AddressId = 68
            };
            applicationUser8.PasswordHash = pH.HashPassword(applicationUser8, "Testpass8!");


            ApplicationUser applicationUser9 = new ApplicationUser
            {
                UserName = "Testbot9@yahoo.com",
                Email = "Testbot9@yahoo.com",
                NormalizedEmail = "Testbot9@yahoo.com".ToUpper(),
                NormalizedUserName = "Testbot9@yahoo.com".ToUpper(),
                TwoFactorEnabled = false,
                EmailConfirmed = true,
                FirstName = "Test9",
                LastName = "Bot9",
                BirthDate = new DateTime(1999, 9, 9),
                Age = 22,
                Gender = GenderType.Male,
                Details = "Hi, I am Bot9!",
                AddressId = 81
            };
            applicationUser9.PasswordHash = pH.HashPassword(applicationUser9, "Testpass9!");


            ApplicationUser applicationUser10 = new ApplicationUser
            {
                UserName = "Testbot10@yahoo.com",
                Email = "Testbot10@yahoo.com",
                NormalizedEmail = "Testbot10@yahoo.com".ToUpper(),
                NormalizedUserName = "Testbot10@yahoo.com".ToUpper(),
                TwoFactorEnabled = false,
                EmailConfirmed = true,
                FirstName = "Test10",
                LastName = "Bot10",
                BirthDate = new DateTime(2000, 10, 10),
                Age = 20,
                Gender = GenderType.Female,
                Details = "Hi, I am Bot10!",
                AddressId = 84
            };
            applicationUser10.PasswordHash = pH.HashPassword(applicationUser10, "Testpass10!");

            builder.Entity<ApplicationUser>()
                .HasData(
                applicationUser1,
                applicationUser2,
                applicationUser3,
                applicationUser4,
                applicationUser5,
                applicationUser6,
                applicationUser7,
                applicationUser8,
                applicationUser9,
                applicationUser10
                );

            #endregion

            #region Advertisement seed
            builder.Entity<Advertisement>()
                .HasData(
            new Advertisement { Advertisement_Id = 1, ProfileId = applicationUser1.Id, CheckInDate = new DateTime(2021, 10, 1) },
            new Advertisement { Advertisement_Id = 2, ProfileId = applicationUser5.Id, CheckInDate = new DateTime(2021, 9, 15)},
            new Advertisement { Advertisement_Id = 3, ProfileId = applicationUser4.Id, CheckInDate = new DateTime(2021, 10, 1)}
            );
            #endregion

            #region Roles seed
            builder.Entity<IdentityRole>()
                .HasData(
            new IdentityRole { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "User", NormalizedName = "USER", ConcurrencyStamp = "1"},
            new IdentityRole { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = "Administrator", NormalizedName = "ADMINISTRATOR", ConcurrencyStamp = "2" }
                );
            #endregion
        }
    }
}
