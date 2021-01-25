using Microsoft.EntityFrameworkCore.Migrations;

namespace Electronics.Data.Migrations
{
    public partial class addedorders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DeliveredAndDone",
                table: "Order",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "GettingDelivered",
                table: "Order",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Payed",
                table: "Order",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PaymentCheck",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveredAndDone",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "GettingDelivered",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Payed",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "PaymentCheck",
                table: "Order");
        }
    }
}
