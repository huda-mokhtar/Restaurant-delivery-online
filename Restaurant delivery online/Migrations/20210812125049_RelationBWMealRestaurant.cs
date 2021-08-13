using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurant_delivery_online.Migrations
{
    public partial class RelationBWMealRestaurant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "Meals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Meals_RestaurantId",
                table: "Meals",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Restaurants_RestaurantId",
                table: "Meals",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Restaurants_RestaurantId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_RestaurantId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Meals");
        }
    }
}
