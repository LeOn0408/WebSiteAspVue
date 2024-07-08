using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class tag_article_relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ap_article_ap_article_tags_TagId",
                table: "ap_article");

            migrationBuilder.DropForeignKey(
                name: "FK_ap_article_tags_ap_users_CreatedByUserId",
                table: "ap_article_tags");

            migrationBuilder.DropForeignKey(
                name: "FK_ap_article_tags_ap_users_LastEditedByUserId",
                table: "ap_article_tags");

            migrationBuilder.DropIndex(
                name: "IX_ap_article_TagId",
                table: "ap_article");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ap_article_tags",
                table: "ap_article_tags");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "ap_article");

            migrationBuilder.RenameTable(
                name: "ap_article_tags",
                newName: "ap_tags");

            migrationBuilder.RenameIndex(
                name: "IX_ap_article_tags_LastEditedByUserId",
                table: "ap_tags",
                newName: "IX_ap_tags_LastEditedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ap_article_tags_CreatedByUserId",
                table: "ap_tags",
                newName: "IX_ap_tags_CreatedByUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ap_tags",
                table: "ap_tags",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ap_article_tag_relation",
                columns: table => new
                {
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false),
                    LastEditDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ap_article_tag_relation", x => new { x.ArticleId, x.TagId });
                    table.ForeignKey(
                        name: "FK_ap_article_tag_relation_ap_article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "ap_article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ap_article_tag_relation_ap_tags_TagId",
                        column: x => x.TagId,
                        principalTable: "ap_tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ap_article_tag_relation_TagId",
                table: "ap_article_tag_relation",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_ap_tags_ap_users_CreatedByUserId",
                table: "ap_tags",
                column: "CreatedByUserId",
                principalTable: "ap_users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ap_tags_ap_users_LastEditedByUserId",
                table: "ap_tags",
                column: "LastEditedByUserId",
                principalTable: "ap_users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ap_tags_ap_users_CreatedByUserId",
                table: "ap_tags");

            migrationBuilder.DropForeignKey(
                name: "FK_ap_tags_ap_users_LastEditedByUserId",
                table: "ap_tags");

            migrationBuilder.DropTable(
                name: "ap_article_tag_relation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ap_tags",
                table: "ap_tags");

            migrationBuilder.RenameTable(
                name: "ap_tags",
                newName: "ap_article_tags");

            migrationBuilder.RenameIndex(
                name: "IX_ap_tags_LastEditedByUserId",
                table: "ap_article_tags",
                newName: "IX_ap_article_tags_LastEditedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ap_tags_CreatedByUserId",
                table: "ap_article_tags",
                newName: "IX_ap_article_tags_CreatedByUserId");

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "ap_article",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ap_article_tags",
                table: "ap_article_tags",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ap_article_TagId",
                table: "ap_article",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_ap_article_ap_article_tags_TagId",
                table: "ap_article",
                column: "TagId",
                principalTable: "ap_article_tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ap_article_tags_ap_users_CreatedByUserId",
                table: "ap_article_tags",
                column: "CreatedByUserId",
                principalTable: "ap_users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ap_article_tags_ap_users_LastEditedByUserId",
                table: "ap_article_tags",
                column: "LastEditedByUserId",
                principalTable: "ap_users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
