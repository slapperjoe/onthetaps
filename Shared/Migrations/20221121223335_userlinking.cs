using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnTheTaps.Shared.Migrations
{
    /// <inheritdoc />
    public partial class userlinking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LoginType",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VenueId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_VenueId",
                table: "Users",
                column: "VenueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Venues_VenueId",
                table: "Users",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "VenueId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Venues_VenueId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_VenueId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LoginType",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "VenueId",
                table: "Users");
        }
    }
}
