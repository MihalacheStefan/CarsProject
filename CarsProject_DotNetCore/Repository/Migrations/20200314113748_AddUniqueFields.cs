using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class AddUniqueFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CodeNumber",
                table: "Chassiss",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "Cars",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Engines_CylindersNumber",
                table: "Engines",
                column: "CylindersNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chassiss_CodeNumber",
                table: "Chassiss",
                column: "CodeNumber",
                unique: true,
                filter: "[CodeNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_Brand",
                table: "Cars",
                column: "Brand",
                unique: true,
                filter: "[Brand] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Engines_CylindersNumber",
                table: "Engines");

            migrationBuilder.DropIndex(
                name: "IX_Chassiss_CodeNumber",
                table: "Chassiss");

            migrationBuilder.DropIndex(
                name: "IX_Cars_Brand",
                table: "Cars");

            migrationBuilder.AlterColumn<string>(
                name: "CodeNumber",
                table: "Chassiss",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "Cars",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
