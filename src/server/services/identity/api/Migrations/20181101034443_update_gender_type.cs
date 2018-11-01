using Microsoft.EntityFrameworkCore.Migrations;

namespace Ncc.China.Services.Identity.Api.Migrations
{
    public partial class update_gender_type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<sbyte>(
                name: "gender",
                table: "user_profile",
                type: "tinyint(3)",
                nullable: false,
                oldClrType: typeof(sbyte),
                oldType: "tinyint(1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<sbyte>(
                name: "gender",
                table: "user_profile",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(sbyte),
                oldType: "tinyint(3)");
        }
    }
}
