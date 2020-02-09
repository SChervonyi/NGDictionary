using Microsoft.EntityFrameworkCore.Migrations;

namespace NGDictionary.Database.Migrations
{
    public partial class ConfigurationFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Words",
                type: "varchar(2083)",
                maxLength: 2083,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(2083)",
                oldMaxLength: 2083);

            migrationBuilder.AlterColumn<string>(
                name: "AudioUrl",
                table: "Words",
                type: "varchar(2083)",
                maxLength: 2083,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(2083)",
                oldMaxLength: 2083);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Dictionaries",
                type: "varchar(2083)",
                maxLength: 2083,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(2083)",
                oldMaxLength: 2083);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Dictionaries",
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(512)",
                oldMaxLength: 512);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Words",
                type: "varchar(2083)",
                maxLength: 2083,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(2083)",
                oldMaxLength: 2083,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AudioUrl",
                table: "Words",
                type: "varchar(2083)",
                maxLength: 2083,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(2083)",
                oldMaxLength: 2083,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Dictionaries",
                type: "varchar(2083)",
                maxLength: 2083,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(2083)",
                oldMaxLength: 2083,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Dictionaries",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 512,
                oldNullable: true);
        }
    }
}
