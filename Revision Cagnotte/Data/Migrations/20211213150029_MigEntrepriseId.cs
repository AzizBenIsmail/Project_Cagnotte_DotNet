using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class MigEntrepriseId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cagnotte_Entreprise_EntrepriseId",
                table: "Cagnotte");

            migrationBuilder.AlterColumn<int>(
                name: "EntrepriseId",
                table: "Cagnotte",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cagnotte_Entreprise_EntrepriseId",
                table: "Cagnotte",
                column: "EntrepriseId",
                principalTable: "Entreprise",
                principalColumn: "EntrepriseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cagnotte_Entreprise_EntrepriseId",
                table: "Cagnotte");

            migrationBuilder.AlterColumn<int>(
                name: "EntrepriseId",
                table: "Cagnotte",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Cagnotte_Entreprise_EntrepriseId",
                table: "Cagnotte",
                column: "EntrepriseId",
                principalTable: "Entreprise",
                principalColumn: "EntrepriseId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
