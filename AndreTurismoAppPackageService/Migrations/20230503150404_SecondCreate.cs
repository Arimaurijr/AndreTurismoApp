using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AndreTurismoAppPackageService.Migrations
{
    public partial class SecondCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketModel_ClientModel_ClienteId",
                table: "TicketModel");

            migrationBuilder.DropIndex(
                name: "IX_TicketModel_ClienteId",
                table: "TicketModel");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "TicketModel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "TicketModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TicketModel_ClienteId",
                table: "TicketModel",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketModel_ClientModel_ClienteId",
                table: "TicketModel",
                column: "ClienteId",
                principalTable: "ClientModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
