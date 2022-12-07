using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MauiMessengerApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatUsers",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoreSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    AvatarSourceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsOnline = table.Column<bool>(type: "bit", nullable: false),
                    LastLogonTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatUsers", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatUsers");
        }
    }
}
