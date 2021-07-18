using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudApplication.Migrations
{
    public partial class AddedGenderInInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Infos",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Departments",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Infos");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Departments",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
