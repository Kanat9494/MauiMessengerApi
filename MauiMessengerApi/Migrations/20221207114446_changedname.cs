using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MauiMessengerApi.Migrations
{
    public partial class changedname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StoreSalt",
                table: "ChatUsers",
                newName: "StoredSalt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StoredSalt",
                table: "ChatUsers",
                newName: "StoreSalt");
        }
    }
}
