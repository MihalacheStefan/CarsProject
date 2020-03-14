using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class CarsUsers_DbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarUser_Cars_CarId",
                table: "CarUser");

            migrationBuilder.DropForeignKey(
                name: "FK_CarUser_Users_UserId",
                table: "CarUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarUser",
                table: "CarUser");

            migrationBuilder.RenameTable(
                name: "CarUser",
                newName: "CarsUsers");

            migrationBuilder.RenameIndex(
                name: "IX_CarUser_UserId",
                table: "CarsUsers",
                newName: "IX_CarsUsers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CarUser_CarId",
                table: "CarsUsers",
                newName: "IX_CarsUsers_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarsUsers",
                table: "CarsUsers",
                column: "CarUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarsUsers_Cars_CarId",
                table: "CarsUsers",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarsUsers_Users_UserId",
                table: "CarsUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarsUsers_Cars_CarId",
                table: "CarsUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_CarsUsers_Users_UserId",
                table: "CarsUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarsUsers",
                table: "CarsUsers");

            migrationBuilder.RenameTable(
                name: "CarsUsers",
                newName: "CarUser");

            migrationBuilder.RenameIndex(
                name: "IX_CarsUsers_UserId",
                table: "CarUser",
                newName: "IX_CarUser_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CarsUsers_CarId",
                table: "CarUser",
                newName: "IX_CarUser_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarUser",
                table: "CarUser",
                column: "CarUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarUser_Cars_CarId",
                table: "CarUser",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarUser_Users_UserId",
                table: "CarUser",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
