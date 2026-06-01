using choir_app.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace choir_app.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<News> News { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<ChoirMember> ChoirMembers { get; set; }
        public DbSet<GalleryImage> GalleryImages { get; set; }
        public DbSet<FileResource> FileResources { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // EVENTS SEED
            builder.Entity<Events>().HasData(
                new Events
                {
                    Id = 1,
                    Name = "Koncert Bożonarodzeniowy",
                    Date = new DateTime(2026, 12, 20),
                    Location = "Kraków"
                },
                new Events
                {
                    Id = 2,
                    Name = "Próba generalna",
                    Date = new DateTime(2026, 12, 15),
                    Location = "Sala prób"
                }
            );

            // NEWS SEED
            builder.Entity<News>().HasData(
                new News
                {
                    Id = 1,
                    Title = "Nowy repertuar",
                    Content = "Dodano nowe utwory do ćwiczeń",
                    CreatedAt = new DateTime(2026, 01, 10)
                },
                new News
                {
                    Id = 2,
                    Title = "Zmiana harmonogramu",
                    Content = "Próby w piątki zamiast środy",
                    CreatedAt = new DateTime(2026, 01, 12)
                }
            );

            // IDENTITY SEED (USER)
            var hasher = new PasswordHasher<ApplicationUser>();

            var adminUser = new ApplicationUser
            {
                Id = "1",
                UserName = "admin@choir.pl",
                NormalizedUserName = "ADMIN@CHOIR.PL",
                Email = "admin@choir.pl",
                NormalizedEmail = "ADMIN@CHOIR.PL",
                EmailConfirmed = true,
                IsActive = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            adminUser.PasswordHash = hasher.HashPassword(adminUser, "Admin123!");

            var memberUser = new ApplicationUser
            {
                Id = "2",
                UserName = "jan.kowalski@choir.pl",
                NormalizedUserName = "JAN.KOWALSKI@CHOIR.PL",
                Email = "jan.kowalski@choir.pl",
                NormalizedEmail = "JAN.KOWALSKI@CHOIR.PL",
                EmailConfirmed = true,
                IsActive = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            memberUser.PasswordHash = hasher.HashPassword(memberUser, "User123!");

            builder.Entity<ApplicationUser>().HasData(adminUser);

            builder.Entity<ApplicationUser>().HasData(memberUser);

            // CHOIR MEMBER SEED
            builder.Entity<ChoirMember>().HasData(
                new ChoirMember
                {
                    Id = 1,
                    UserId = "1",
                    Voice = Models.Enums.VoiceType.Sopran1,
                    JoinDate = new DateTime(2025, 01, 01),
                    IsActive = true,
                    Notes = "Admin chór"
                }
            );

            builder.Entity<ChoirMember>().HasData(
                new ChoirMember
                {
                    Id = 2,
                    UserId = "2",
                    Voice = Models.Enums.VoiceType.Tenor1,
                    JoinDate = new DateTime(2025, 02, 01),
                    IsActive = true,
                    Notes = "Jan Kowalski"
                }
            );

            // GALLERY SEED
            builder.Entity<GalleryImage>().HasData(
                new GalleryImage
                {
                    Id = 1,
                    ImageUrl = "/gallery/photo1.jpg",
                    Title = "Koncert 2025",
                    CreatedAt = new DateTime(2025, 12, 20),
                    UploadedById = "1"
                }
            );

            builder.Entity<FileResource>().HasData(
                new FileResource
                {
                    Id = 1,
                    FileName = "nuty.pdf",
                    FilePath = "/files/pdf/nuty.pdf",
                    FileType = "pdf",
                    UploadedAt = new DateTime(2025, 01, 01)
                }
            );
        }
    }
}