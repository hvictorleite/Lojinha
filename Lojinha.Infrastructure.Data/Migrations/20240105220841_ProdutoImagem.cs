using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lojinha.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProdutoImagem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProdutoImagens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Base64 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoImagens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdutoImagens_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoImagens_ProdutoId",
                table: "ProdutoImagens",
                column: "ProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutoImagens");
        }
    }
}
