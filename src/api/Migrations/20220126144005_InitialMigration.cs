using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace challengePaggcerto.src.api.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anticipations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartAnalysisDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinalAnalysisDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AnalysisState = table.Column<int>(type: "int", nullable: false),
                    AnticipatedRequiredValue = table.Column<double>(type: "float", nullable: false),
                    AnticipatedValue = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anticipations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateExecuted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateAccepted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateRejected = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Anticipated = table.Column<bool>(type: "bit", nullable: false),
                    AcquirerConfirm = table.Column<bool>(type: "bit", nullable: false),
                    GrossValue = table.Column<double>(type: "float", nullable: false),
                    NetValue = table.Column<double>(type: "float", nullable: false),
                    FixRate = table.Column<double>(type: "float", nullable: false),
                    ParcelAmount = table.Column<int>(type: "int", nullable: false),
                    LastFourCardDigits = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnticipationId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Anticipations_AnticipationId",
                        column: x => x.AnticipationId,
                        principalTable: "Anticipations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Parcels",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionId = table.Column<long>(type: "bigint", nullable: true),
                    GrossValue = table.Column<double>(type: "float", nullable: false),
                    NetValue = table.Column<double>(type: "float", nullable: false),
                    ParcelNumber = table.Column<int>(type: "int", nullable: false),
                    ValueAnticipated = table.Column<double>(type: "float", nullable: false),
                    DateReceived = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatePassedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parcels_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parcels_TransactionId",
                table: "Parcels",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AnticipationId",
                table: "Transactions",
                column: "AnticipationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parcels");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Anticipations");
        }
    }
}
