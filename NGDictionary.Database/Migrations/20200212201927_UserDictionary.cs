using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NGDictionary.Database.Migrations
{
    public partial class UserDictionary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserDictionary",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    DictionaryId = table.Column<Guid>(nullable: false),
                    DictionaryMetaId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDictionary", x => new { x.UserId, x.DictionaryId });
                    table.ForeignKey(
                        name: "FK_UserDictionary_Dictionaries_DictionaryId",
                        column: x => x.DictionaryId,
                        principalTable: "Dictionaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDictionary_Dictionaries_DictionaryMetaId",
                        column: x => x.DictionaryMetaId,
                        principalTable: "Dictionaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserDictionary_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserDictionary_DictionaryId",
                table: "UserDictionary",
                column: "DictionaryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDictionary_DictionaryMetaId",
                table: "UserDictionary",
                column: "DictionaryMetaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDictionary");
        }
    }
}
