using Microsoft.EntityFrameworkCore.Migrations;

namespace BusReervationAPI.Migrations
{
    public partial class BookingInfo2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SeatNo",
                table: "BookingInfos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeatNo",
                table: "BookingInfos");
        }
    }
}
