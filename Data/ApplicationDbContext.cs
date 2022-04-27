using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Notes_Website.Models;

namespace Notes_Website.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Notes_Website.Models.NoteModel> NoteModel { get; set; }
        public DbSet<Notes_Website.Models.NoteType> NoteTypes { get; set; }
        public DbSet<Notes_Website.Models.AmendmentModel> AmendmentModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<NoteType>().HasData(
                new NoteType
                {
                    Id = 1,
                    Type = "Personal"
                },
                new NoteType
                {
                    Id = 2,
                    Type = "School"
                },
                new NoteType
                {
                    Id = 3,
                    Type = "Random"
                },
                new NoteType
                {
                    Id = 4,
                    Type = "Important"
                },
                new NoteType
                {
                    Id = 5,
                    Type = "Other"
                }
                );

            modelBuilder.Entity<NoteModel>().HasData(
                new NoteModel
                {
                    Id = 4,
                    Title = "Remember",
                    Note = "Johns birthday is soon.",
                    Added = DateTime.Now.AddDays(-4),
                    Note_Part = 1,
                    NoteTypeId = 1
                },
                new NoteModel
                {
                    Id = 5,
                    Title = "Test Help",
                    Note = "Look over notes for the test.",
                    Added = DateTime.Now.AddDays(-5),
                    Note_Part = 1,
                    NoteTypeId = 2
                },
                new NoteModel
                {
                    Id = 6,
                    Title = "Note Title",
                    Note = "Link to website.",
                    Added = DateTime.Now.AddDays(-1),
                    Note_Part = 1,
                    NoteTypeId = 3
                },
                new NoteModel
                {
                    Id = 7,
                    Title = "Upcoming Meeting",
                    Note = "Don't miss today's meeting.",
                    Added = DateTime.Now,
                    Note_Part = 1,
                    NoteTypeId = 4
                },
                new NoteModel
                {
                    Id = 8,
                    Title = "Car Help",
                    Note = "To fix the ....",
                    Added = DateTime.Now.AddDays(-1),
                    Note_Part = 1,
                    NoteTypeId = 5
                }
                );
        }
    }
}