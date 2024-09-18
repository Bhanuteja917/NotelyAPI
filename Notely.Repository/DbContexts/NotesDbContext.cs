using Microsoft.EntityFrameworkCore;
using Notely.Repository.Entities; 

namespace Notely.Repository.DbContexts
{
    public class NotesDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Notes> Notes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(new User
                {
                    Id = Guid.NewGuid(),
                    Username = "bhanuteja917",
                    Password = "Password",
                    FirstName = "Bhanuteja",
                    LastName = "Chintha"
                });
            modelBuilder.Entity<Notes>()
                .HasData(
                    new Notes()
                    {
                        Id = 1,
                        Title = "Exploring the Wilderness",
                        Category = "Home",
                        Description = "Embark on an adventure through the untamed wilderness and discover hidden treasures."
                    },
                    new Notes()
                    {
                        Id = 2,
                        Title = "Unleashing Business Potential",
                        Category = "Business",
                        Description = "Unleash the full potential of your business and witness unprecedented growth and success."
                    },
                    new Notes()
                    {
                        Id = 3,
                        Title = "Journey to Self-Discovery",
                        Category = "Personal",
                        Description = "Embark on a transformative journey of self-discovery and unlock your true potential."
                    },
                    new Notes()
                    {
                        Id = 4,
                        Title = "Creating a Cozy Home",
                        Category = "Home",
                        Description = "Transform your house into a cozy sanctuary where warmth and comfort embrace you."
                    },
                    new Notes()
                    {
                        Id = 5,
                        Title = "Innovative Business Strategies",
                        Category = "Business",
                        Description = "Explore innovative strategies that will revolutionize your business and leave your competitors in awe."
                    },
                    new Notes()
                    {
                        Id = 6,
                        Title = "Embracing Personal Growth",
                        Category = "Personal",
                        Description = "Embrace personal growth and witness the incredible transformation that unfolds within you."
                    },
                    new Notes()
                    {
                        Id = 7,
                        Title = "Home Sweet Home",
                        Category = "Home",
                        Description = "Experience the joy and comfort of a home that radiates warmth and love."
                    },
                    new Notes()
                    {
                        Id = 8,
                        Title = "Business Mastery",
                        Category = "Business",
                        Description = "Master the art of business and become a visionary leader in your industry."
                    },
                    new Notes()
                    {
                        Id = 9,
                        Title = "Unleashing Inner Potential",
                        Category = "Personal",
                        Description = "Unleash your inner potential and embark on a journey of self-discovery and personal growth."
                    },
                    new Notes()
                    {
                        Id = 10,
                        Title = "Creating a Serene Haven",
                        Category = "Home",
                        Description = "Create a serene haven where tranquility and peace envelop your senses."
                    }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
