using Microsoft.EntityFrameworkCore.Migrations;

namespace CandyShop.Migrations
{
    public partial class UpdateShopingCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopingCardItems_Products_ProductsId",
                table: "ShopingCardItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShopingCardItems",
                table: "ShopingCardItems");

            migrationBuilder.DropColumn(
                name: "ShopingCardKey",
                table: "ShopingCardItems");

            migrationBuilder.RenameTable(
                name: "ShopingCardItems",
                newName: "ShopingCard");

            migrationBuilder.RenameIndex(
                name: "IX_ShopingCardItems_ProductsId",
                table: "ShopingCard",
                newName: "IX_ShopingCard_ProductsId");

            migrationBuilder.AddColumn<string>(
                name: "ShopingCardId",
                table: "ShopingCard",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShopingCard",
                table: "ShopingCard",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopingCard_Products_ProductsId",
                table: "ShopingCard",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopingCard_Products_ProductsId",
                table: "ShopingCard");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShopingCard",
                table: "ShopingCard");

            migrationBuilder.DropColumn(
                name: "ShopingCardId",
                table: "ShopingCard");

            migrationBuilder.RenameTable(
                name: "ShopingCard",
                newName: "ShopingCardItems");

            migrationBuilder.RenameIndex(
                name: "IX_ShopingCard_ProductsId",
                table: "ShopingCardItems",
                newName: "IX_ShopingCardItems_ProductsId");

            migrationBuilder.AddColumn<string>(
                name: "ShopingCardKey",
                table: "ShopingCardItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShopingCardItems",
                table: "ShopingCardItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopingCardItems_Products_ProductsId",
                table: "ShopingCardItems",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
