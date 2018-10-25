using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ncc.China.Services.Identity.Api.Migrations
{
    public partial class init_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<string>(type: "char(32)", nullable: false),
                    username = table.Column<string>(type: "varchar(50)", nullable: false),
                    email = table.Column<string>(type: "varchar(100)", nullable: false),
                    password = table.Column<string>(type: "varchar(256)", nullable: false),
                    salt = table.Column<string>(type: "varchar(50)", nullable: false),
                    is_deleted = table.Column<sbyte>(type: "tinyint(2)", nullable: false),
                    is_admin = table.Column<sbyte>(type: "tinyint(2)", nullable: false),
                    utc_created = table.Column<DateTime>(type: "datetime", nullable: false),
                    utc_updated = table.Column<DateTime>(type: "datetime ", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_profile",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<string>(type: "char(32)", nullable: false),
                    nickname = table.Column<string>(type: "varchar(100)", nullable: true),
                    bio = table.Column<string>(type: "varchar(200)", nullable: true),
                    gender = table.Column<sbyte>(type: "tinyint(1)", nullable: false),
                    avatar_url = table.Column<string>(type: "text", nullable: true),
                    utc_created = table.Column<DateTime>(type: "datetime", nullable: false),
                    utc_updated = table.Column<DateTime>(type: "datetime ", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_id", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "user_profile");
        }
    }
}
