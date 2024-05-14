using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class rename_news_to_article : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ap_refresh_token_ap_users_UserId",
                table: "ap_refresh_token");

            migrationBuilder.DropTable(
                name: "ap_news");

            migrationBuilder.DropTable(
                name: "ap_news_sections");

            migrationBuilder.DropTable(
                name: "ap_news_tags");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ap_refresh_token",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "ap_refresh_token",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ap_article_sections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastEditDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    LastEditedByUserId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ap_article_sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ap_article_sections_ap_users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "ap_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ap_article_sections_ap_users_LastEditedByUserId",
                        column: x => x.LastEditedByUserId,
                        principalTable: "ap_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ap_article_tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastEditDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    LastEditedByUserId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ap_article_tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ap_article_tags_ap_users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "ap_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ap_article_tags_ap_users_LastEditedByUserId",
                        column: x => x.LastEditedByUserId,
                        principalTable: "ap_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ap_article",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastEditDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    LastEditedByUserId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ap_article", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ap_article_ap_article_sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "ap_article_sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ap_article_ap_article_tags_TagId",
                        column: x => x.TagId,
                        principalTable: "ap_article_tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ap_article_ap_images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "ap_images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ap_article_ap_users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "ap_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ap_article_ap_users_LastEditedByUserId",
                        column: x => x.LastEditedByUserId,
                        principalTable: "ap_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ap_article_CreatedByUserId",
                table: "ap_article",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ap_article_ImageId",
                table: "ap_article",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ap_article_LastEditedByUserId",
                table: "ap_article",
                column: "LastEditedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ap_article_SectionId",
                table: "ap_article",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ap_article_TagId",
                table: "ap_article",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_ap_article_sections_CreatedByUserId",
                table: "ap_article_sections",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ap_article_sections_LastEditedByUserId",
                table: "ap_article_sections",
                column: "LastEditedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ap_article_tags_CreatedByUserId",
                table: "ap_article_tags",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ap_article_tags_LastEditedByUserId",
                table: "ap_article_tags",
                column: "LastEditedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ap_refresh_token_ap_users_UserId",
                table: "ap_refresh_token",
                column: "UserId",
                principalTable: "ap_users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ap_refresh_token_ap_users_UserId",
                table: "ap_refresh_token");

            migrationBuilder.DropTable(
                name: "ap_article");

            migrationBuilder.DropTable(
                name: "ap_article_sections");

            migrationBuilder.DropTable(
                name: "ap_article_tags");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ap_refresh_token",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ap_refresh_token",
                keyColumn: "Token",
                keyValue: null,
                column: "Token",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "ap_refresh_token",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ap_news_sections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    LastEditedByUserId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LastEditDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ap_news_sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ap_news_sections_ap_users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "ap_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ap_news_sections_ap_users_LastEditedByUserId",
                        column: x => x.LastEditedByUserId,
                        principalTable: "ap_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ap_news_tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    LastEditedByUserId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LastEditDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ap_news_tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ap_news_tags_ap_users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "ap_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ap_news_tags_ap_users_LastEditedByUserId",
                        column: x => x.LastEditedByUserId,
                        principalTable: "ap_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ap_news",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    LastEditedByUserId = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LastEditDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ap_news", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ap_news_ap_images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "ap_images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ap_news_ap_news_sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "ap_news_sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ap_news_ap_news_tags_TagId",
                        column: x => x.TagId,
                        principalTable: "ap_news_tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ap_news_ap_users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "ap_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ap_news_ap_users_LastEditedByUserId",
                        column: x => x.LastEditedByUserId,
                        principalTable: "ap_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ap_news_CreatedByUserId",
                table: "ap_news",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ap_news_ImageId",
                table: "ap_news",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ap_news_LastEditedByUserId",
                table: "ap_news",
                column: "LastEditedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ap_news_SectionId",
                table: "ap_news",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ap_news_TagId",
                table: "ap_news",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_ap_news_sections_CreatedByUserId",
                table: "ap_news_sections",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ap_news_sections_LastEditedByUserId",
                table: "ap_news_sections",
                column: "LastEditedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ap_news_tags_CreatedByUserId",
                table: "ap_news_tags",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ap_news_tags_LastEditedByUserId",
                table: "ap_news_tags",
                column: "LastEditedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ap_refresh_token_ap_users_UserId",
                table: "ap_refresh_token",
                column: "UserId",
                principalTable: "ap_users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
