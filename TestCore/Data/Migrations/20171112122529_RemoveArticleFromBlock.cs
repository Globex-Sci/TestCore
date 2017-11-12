using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TestCore.Data.Migrations
{
    public partial class RemoveArticleFromBlock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blocks_Articles_ArticleHash",
                table: "Blocks");

            migrationBuilder.DropIndex(
                name: "IX_Blocks_ArticleHash",
                table: "Blocks");

            migrationBuilder.DropColumn(
                name: "ArticleHash",
                table: "Blocks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ArticleHash",
                table: "Blocks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blocks_ArticleHash",
                table: "Blocks",
                column: "ArticleHash");

            migrationBuilder.AddForeignKey(
                name: "FK_Blocks_Articles_ArticleHash",
                table: "Blocks",
                column: "ArticleHash",
                principalTable: "Articles",
                principalColumn: "ArticleHash",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
