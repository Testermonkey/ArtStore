using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtStore.Migrations
{
    /// <inheritdoc />
    public partial class from_ArtWorkName_to_ArtworkArtWorkName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Artworks",
                newName: "ArtworkName");

            migrationBuilder.AddColumn<string>(
                name: "ArtworkImageURL",
                table: "Artworks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArtworkImageURL",
                table: "Artworks");

            migrationBuilder.RenameColumn(
                name: "ArtworkName",
                table: "Artworks",
                newName: "Name");
        }
    }
}
