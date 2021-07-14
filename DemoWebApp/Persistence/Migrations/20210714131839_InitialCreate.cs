using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoWebApp.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(sysdatetime())"),
                    Modified = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(sysdatetime())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(sysdatetime())"),
                    Modified = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(sysdatetime())"),
                    AuthorId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Article_Author",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    AuthorId = table.Column<long>(type: "bigint", nullable: false),
                    ArticleId = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(sysdatetime())"),
                    Modified = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(sysdatetime())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Article_Comment",
                        column: x => x.ArticleId,
                        principalTable: "Article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Author_Comment",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Article_AuthorId",
                table: "Article",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ArticleId",
                table: "Comment",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_AuthorId",
                table: "Comment",
                column: "AuthorId");

            migrationBuilder.Sql("CREATE TRIGGER TRG_AUTHOR_UpdateModifiedDate ON dbo.Author AFTER UPDATE AS UPDATE dbo.Author SET Modified = sysdatetime() WHERE Id IN (SELECT DISTINCT Id FROM inserted)");
            migrationBuilder.Sql("CREATE TRIGGER TRG_ARTICLE_UpdateModifiedDate ON dbo.Article AFTER UPDATE AS UPDATE dbo.Article SET Modified = sysdatetime() WHERE Id IN(SELECT DISTINCT Id FROM inserted)");
            migrationBuilder.Sql("CREATE TRIGGER TRG_COMMENT_UpdateModifiedDate ON dbo.Comment AFTER UPDATE AS UPDATE dbo.Comment SET Modified = sysdatetime() WHERE Id IN(SELECT DISTINCT Id FROM inserted)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "Author");
        }
    }
}
