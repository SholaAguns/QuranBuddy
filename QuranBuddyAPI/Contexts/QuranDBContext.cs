using Microsoft.EntityFrameworkCore;
using QuranBuddyAPI.Models;

namespace QuranBuddyAPI.Contexts
{
    public class QuranDBContext : DbContext
    {
        public QuranDBContext(DbContextOptions<QuranDBContext> options) : base(options) { }

        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Verse> Verses { get; set; }

        public DbSet<Flashcard> Flashcards { get; set; }
        public DbSet<FlashcardSet> FlashcardSets { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chapter>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Verse>()
                .HasKey(v => v.Id);

            modelBuilder.Entity<Chapter>()
             .OwnsOne(c => c.TranslatedName);

            modelBuilder.Entity<Verse>()
             .OwnsMany(v => v.Translations);


            modelBuilder.Entity<Chapter>()
                .HasMany(c => c.Verses)
                .WithOne(v => v.Chapter)
                .HasForeignKey(v => v.ChapterId)
                .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Verse>()
            //.HasOne(c => c.Chapter)  
            //.WithMany(c => c.Verses)  
            //.HasForeignKey(v => v.ChapterId)
            //.IsRequired()
            //.OnDelete(DeleteBehavior.Cascade);
            


            modelBuilder.Entity<Flashcard>()
                .HasKey(f => f.Id);

            modelBuilder.Entity<FlashcardSet>()
                .HasKey(f => f.Id);

            modelBuilder.Entity<FlashcardSet>()
                .HasMany(f => f.Flashcards)
                .WithOne(f => f.FlashcardSet)
                .HasForeignKey(f => f.FlashcardId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
