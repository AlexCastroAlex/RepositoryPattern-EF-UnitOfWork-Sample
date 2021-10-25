using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.EF.UoW.Core.Migrations
{
    public partial class add_catalog_link : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CatalogueId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_CatalogueId",
                table: "Books",
                column: "CatalogueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Catalogs_CatalogueId",
                table: "Books",
                column: "CatalogueId",
                principalTable: "Catalogs",
                principalColumn: "CatalogueId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Catalogs_CatalogueId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_CatalogueId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CatalogueId",
                table: "Books");
        }
    }
}
