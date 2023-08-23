using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class addtagrenametypetosection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ap_news_ap_news_type_TypeId",
                table: "ap_news");

            migrationBuilder.DropTable(
                name: "ap_news_type");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "ap_news",
                newName: "TagId");

            migrationBuilder.RenameIndex(
                name: "IX_ap_news_TypeId",
                table: "ap_news",
                newName: "IX_ap_news_TagId");

            migrationBuilder.AddColumn<int>(
                name: "SectionId",
                table: "ap_news",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ap_news_sections",
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

            migrationBuilder.CreateIndex(
                name: "IX_ap_news_SectionId",
                table: "ap_news",
                column: "SectionId");

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
                name: "FK_ap_news_ap_news_sections_SectionId",
                table: "ap_news",
                column: "SectionId",
                principalTable: "ap_news_sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ap_news_ap_news_tags_TagId",
                table: "ap_news",
                column: "TagId",
                principalTable: "ap_news_tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ap_news_ap_news_sections_SectionId",
                table: "ap_news");

            migrationBuilder.DropForeignKey(
                name: "FK_ap_news_ap_news_tags_TagId",
                table: "ap_news");

            migrationBuilder.DropTable(
                name: "ap_news_sections");

            migrationBuilder.DropTable(
                name: "ap_news_tags");

            migrationBuilder.DropIndex(
                name: "IX_ap_news_SectionId",
                table: "ap_news");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "ap_news");

            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "ap_news",
                newName: "TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ap_news_TagId",
                table: "ap_news",
                newName: "IX_ap_news_TypeId");

            migrationBuilder.CreateTable(
                name: "ap_news_type",
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
                    table.PrimaryKey("PK_ap_news_type", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ap_news_type_ap_users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "ap_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ap_news_type_ap_users_LastEditedByUserId",
                        column: x => x.LastEditedByUserId,
                        principalTable: "ap_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ap_news_type_CreatedByUserId",
                table: "ap_news_type",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ap_news_type_LastEditedByUserId",
                table: "ap_news_type",
                column: "LastEditedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ap_news_ap_news_type_TypeId",
                table: "ap_news",
                column: "TypeId",
                principalTable: "ap_news_type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
