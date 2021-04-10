using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace brokerAgenda.Migrations
{
    public partial class addValidationsForBroker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "broker",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lastname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    firstname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    mail = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    phoneNumber = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_broker", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lastname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    firstname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    mail = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    phoneNumber = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    budget = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "appointment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateHour = table.Column<DateTime>(type: "datetime", nullable: false),
                    subject = table.Column<string>(type: "text", nullable: false),
                    id_broker = table.Column<int>(type: "int", nullable: false),
                    id_customer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointment", x => x.id);
                    table.ForeignKey(
                        name: "appointment_broker_FK",
                        column: x => x.id_broker,
                        principalTable: "broker",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "appointment_customer0_FK",
                        column: x => x.id_customer,
                        principalTable: "customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointment_id_broker",
                table: "appointment",
                column: "id_broker");

            migrationBuilder.CreateIndex(
                name: "IX_appointment_id_customer",
                table: "appointment",
                column: "id_customer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appointment");

            migrationBuilder.DropTable(
                name: "broker");

            migrationBuilder.DropTable(
                name: "customer");
        }
    }
}
