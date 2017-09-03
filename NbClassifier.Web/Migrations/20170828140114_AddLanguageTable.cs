using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NbClassifier.Web.Migrations
{
    public partial class AddLanguageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Language",
                table: "Reviews");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.LanguageId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_LanguageId",
                table: "Reviews",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Language_LanguageId",
                table: "Reviews",
                column: "LanguageId",
                principalTable: "Language",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Language_LanguageId",
                table: "Reviews");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_LanguageId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Reviews");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Reviews",
                nullable: false,
                defaultValue: "");
        }
    }
}
