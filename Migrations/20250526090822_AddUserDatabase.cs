using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.Net.Migrations
{
    /// <inheritdoc />
    public partial class AddUserDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(MAX)", nullable: false, defaultValue: "https://avatar.iran.liara.run/public/19"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Created_At = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    Updated_At = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.UniqueConstraint("UNIQUE_Users_Username", x => x.Username);
                    table.UniqueConstraint("UNIQUE_Users_Email", x => x.Email);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
