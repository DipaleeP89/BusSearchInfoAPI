using Microsoft.EntityFrameworkCore.Migrations;

namespace BusReervationAPI.Migrations
{
    public partial class BookingInfo1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserMobile",
                table: "BookingInfos",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserMobile",
                table: "BookingInfos",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
