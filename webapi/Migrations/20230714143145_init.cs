using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ap_users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsAdmin = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ap_users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ap_images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Path = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                    table.PrimaryKey("PK_ap_images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ap_images_ap_users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "ap_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ap_images_ap_users_LastEditedByUserId",
                        column: x => x.LastEditedByUserId,
                        principalTable: "ap_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ap_news_type",
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

            migrationBuilder.CreateTable(
                name: "ap_users_entity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_ap_users_entity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ap_users_entity_ap_users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "ap_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ap_users_entity_ap_users_LastEditedByUserId",
                        column: x => x.LastEditedByUserId,
                        principalTable: "ap_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ap_users_entity_ap_users_UserId",
                        column: x => x.UserId,
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
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_ap_news", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ap_news_ap_images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "ap_images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ap_news_ap_news_type_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ap_news_type",
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
                name: "IX_ap_images_CreatedByUserId",
                table: "ap_images",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ap_images_LastEditedByUserId",
                table: "ap_images",
                column: "LastEditedByUserId");

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
                name: "IX_ap_news_TypeId",
                table: "ap_news",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ap_news_type_CreatedByUserId",
                table: "ap_news_type",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ap_news_type_LastEditedByUserId",
                table: "ap_news_type",
                column: "LastEditedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ap_users_entity_CreatedByUserId",
                table: "ap_users_entity",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ap_users_entity_LastEditedByUserId",
                table: "ap_users_entity",
                column: "LastEditedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ap_users_entity_UserId",
                table: "ap_users_entity",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ap_news");

            migrationBuilder.DropTable(
                name: "ap_users_entity");

            migrationBuilder.DropTable(
                name: "ap_images");

            migrationBuilder.DropTable(
                name: "ap_news_type");

            migrationBuilder.DropTable(
                name: "ap_users");
        }
    }
}
