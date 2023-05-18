using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entreprise",
                columns: table => new
                {
                    EntrepriseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomEntreprise = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdresseEntreprise = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailEntreprise = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entreprise", x => x.EntrepriseId);
                });

            migrationBuilder.CreateTable(
                name: "Participant",
                columns: table => new
                {
                    ParticipantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailParticipant = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participant", x => x.ParticipantId);
                });

            migrationBuilder.CreateTable(
                name: "Cagnotte",
                columns: table => new
                {
                    CagnotteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SommeDemandée = table.Column<int>(type: "int", nullable: false),
                    DateLimite = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    EntrepriseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cagnotte", x => x.CagnotteId);
                    table.ForeignKey(
                        name: "FK_Cagnotte_Entreprise_EntrepriseId",
                        column: x => x.EntrepriseId,
                        principalTable: "Entreprise",
                        principalColumn: "EntrepriseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Participation",
                columns: table => new
                {
                    ParticipantFk = table.Column<int>(type: "int", nullable: false),
                    CagnotteFk = table.Column<int>(type: "int", nullable: false),
                    Montant = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participation", x => new { x.CagnotteFk, x.ParticipantFk });
                    table.ForeignKey(
                        name: "FK_Participation_Cagnotte_CagnotteFk",
                        column: x => x.CagnotteFk,
                        principalTable: "Cagnotte",
                        principalColumn: "CagnotteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participation_Participant_ParticipantFk",
                        column: x => x.ParticipantFk,
                        principalTable: "Participant",
                        principalColumn: "ParticipantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cagnotte_EntrepriseId",
                table: "Cagnotte",
                column: "EntrepriseId");

            migrationBuilder.CreateIndex(
                name: "IX_Participation_ParticipantFk",
                table: "Participation",
                column: "ParticipantFk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participation");

            migrationBuilder.DropTable(
                name: "Cagnotte");

            migrationBuilder.DropTable(
                name: "Participant");

            migrationBuilder.DropTable(
                name: "Entreprise");
        }
    }
}
