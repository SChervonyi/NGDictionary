using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NGDictionary.Database.Migrations
{
    public partial class DeleteDictionaryMeta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDictionary_Dictionaries_DictionaryMetaId",
                table: "UserDictionary");

            migrationBuilder.DropIndex(
                name: "IX_UserDictionary_DictionaryMetaId",
                table: "UserDictionary");

            migrationBuilder.DropColumn(
                name: "DictionaryMetaId",
                table: "UserDictionary");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DictionaryMetaId",
                table: "UserDictionary",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserDictionary_DictionaryMetaId",
                table: "UserDictionary",
                column: "DictionaryMetaId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDictionary_Dictionaries_DictionaryMetaId",
                table: "UserDictionary",
                column: "DictionaryMetaId",
                principalTable: "Dictionaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
