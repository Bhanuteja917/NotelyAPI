using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Notely.Repository.Migrations
{
    /// <inheritdoc />
    public partial class NotelyDbInitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Category = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "Category", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Home", "Embark on an adventure through the untamed wilderness and discover hidden treasures.", "Exploring the Wilderness" },
                    { 2, "Business", "Unleash the full potential of your business and witness unprecedented growth and success.", "Unleashing Business Potential" },
                    { 3, "Personal", "Embark on a transformative journey of self-discovery and unlock your true potential.", "Journey to Self-Discovery" },
                    { 4, "Home", "Transform your house into a cozy sanctuary where warmth and comfort embrace you.", "Creating a Cozy Home" },
                    { 5, "Business", "Explore innovative strategies that will revolutionize your business and leave your competitors in awe.", "Innovative Business Strategies" },
                    { 6, "Personal", "Embrace personal growth and witness the incredible transformation that unfolds within you.", "Embracing Personal Growth" },
                    { 7, "Home", "Experience the joy and comfort of a home that radiates warmth and love.", "Home Sweet Home" },
                    { 8, "Business", "Master the art of business and become a visionary leader in your industry.", "Business Mastery" },
                    { 9, "Personal", "Unleash your inner potential and embark on a journey of self-discovery and personal growth.", "Unleashing Inner Potential" },
                    { 10, "Home", "Create a serene haven where tranquility and peace envelop your senses.", "Creating a Serene Haven" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");
        }
    }
}
